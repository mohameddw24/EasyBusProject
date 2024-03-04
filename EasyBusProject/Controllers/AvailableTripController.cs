using EasyBus.Models;
using EasyBusProject.Models;
using EasyBusProject.RepoServices;
using EasyBusProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace EasyBusProject.Controllers
{
    public class AvailableTripController : Controller
    {
        private readonly IRepository<Trip> _contextTrip;
        private readonly IRepository<Schedule> _contextSchedule;
        private readonly IRepository<Ticket> _contextTicket;
        private readonly UserScheduleRepoServices _contextUserSchedule;
        private readonly UserManager<User> _userManager;

        public AvailableTripController(IRepository<Trip> contextTrip, IRepository<Schedule> contextSchedule, UserScheduleRepoServices contextUserSchedule,TicketRepoService ticketRepoService, UserManager<User> userManager)
        {
            _contextTrip = contextTrip;
            _contextSchedule = contextSchedule;
            _contextUserSchedule = contextUserSchedule;
            _contextTicket = ticketRepoService;
            _userManager = userManager;
        }


        public IActionResult Index(int pickUp, int dropOff, DateOnly date)
        {
            DateOnly _dateOnly = date;
            ViewBag.Date = date;
            ViewData["day"] = date.ToString("dddd");

            var availTrips = _contextTrip.GetAll()
                           .Where(t => t.PickUpID == pickUp && t.DropOffID == dropOff && t.AvailableDays?.Any(av => av.ToString() == date.ToString("dddd")) == true)
                           .ToList();

            return View(availTrips);
        }

        public IActionResult DetailsOfTrip(int id, string date)
        {
            var trip = _contextTrip.GetAll().Where(t => t.Id == id).FirstOrDefault();
            var scheduleTrips = _contextSchedule.GetAll().Where(s => s.TripId == id && s.Date == DateOnly.Parse(date)).FirstOrDefault();
            ViewBag.user = User.FindFirstValue(ClaimTypes.Name);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ticket = new Ticket();
            ViewBag.SeatsTaken = scheduleTrips?.NumOfSeatsReserved?.Split(", ") ?? new string[0];
            ViewBag.tripId = id;
            
            ticket.UserId = int.Parse(userId);
            
            ticket.BusName = trip.Bus.Model;
            ticket.Price = (int)trip.Price;
            ticket.Date = DateOnly.Parse(date);
            ticket.StartFrom = trip.PickUp.Name;
            ticket.Destination = trip.DropOff.Name;
            ticket.Time = trip.Time;
            ticket.NumOfAvailSeats = scheduleTrips?.AvailableSeats ?? (int)trip.Bus.Seats;
            ticket.TotalCapacity = (int)trip.Bus.Seats;
            ticket.Seats = scheduleTrips?.NumOfSeatsReserved ?? "EMPTY";
            ticket.NumOfSeatsOfUser = 0;


            return View(ticket);
        }

        [HttpPost]
        public IActionResult DetailsOfTrip(int id, string date, CheckBoxViewModel checkBoxViewModel,Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(DetailsOfTrip),new {id ,date });
            }
            else
            {
                var trip = _contextTrip.GetAll().Where(t => t.Id == id).FirstOrDefault();
                var scheduleTrips = _contextSchedule.GetAll().Where(s => s.TripId == id && s.Date == DateOnly.Parse(date)).FirstOrDefault();
                string[] checkedIdsAsStrings = checkBoxViewModel.CheckboxValues.Keys.Select(k => k.ToString()).ToArray();
                string joinedCheckedIds = String.Join(", ", checkedIdsAsStrings);
                var userSchedule = new UserSchedule();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                userSchedule.UserId = int.Parse(userId);
                ticket.Price = (int)trip.Price * checkedIdsAsStrings.Length;
                if (scheduleTrips != null)
                {
                    scheduleTrips.NumOfSeatsReserved += ", " + joinedCheckedIds;
                    userSchedule.ScheduleId = scheduleTrips.Id;
                    userSchedule.NumOfSeats = ticket.NumOfSeatsOfUser;
                    userSchedule.SeatsTaken = joinedCheckedIds;
                    _contextUserSchedule.Add(userSchedule);
                    scheduleTrips.AvailableSeatsInTrip = (int)trip.Bus.Seats - _contextUserSchedule.GetAvailableSeats(scheduleTrips.Id);
                    ticket.NumOfAvailSeats = scheduleTrips.AvailableSeatsInTrip;
                    _contextSchedule.Update(scheduleTrips);
                }
                else
                {
                    var newSchedule = new Schedule
                    {
                        TripId = id,
                        Date = DateOnly.Parse(date),
                        AvailableSeatsInTrip = (int)trip.Bus.Seats - ticket.NumOfSeatsOfUser,
                        NumOfSeatsReserved = joinedCheckedIds
                    };
                    _contextSchedule.Add(newSchedule);
                    userSchedule.ScheduleId = newSchedule.Id;
                    userSchedule.NumOfSeats = ticket.NumOfSeatsOfUser;
                    userSchedule.SeatsTaken = joinedCheckedIds;
                    ticket.NumOfAvailSeats = newSchedule.AvailableSeatsInTrip;
                    _contextUserSchedule.Add(userSchedule);
                }
                ticket.Seats = joinedCheckedIds;
                ticket.UserId = int.Parse(userId);
                ticket.Id = 0;
                ticket.Time = trip.Time;
                ticket.TotalCapacity = (int)trip.Bus.Seats;
                ticket.NumOfSeatsOfUser = checkBoxViewModel.CheckboxValues.Count;
                _contextTicket.Add(ticket);
                return RedirectToAction("TicketDetails", ticket);
            }
        }

        public async Task<IActionResult> TicketDetails(Ticket ticket)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.userName = currentUser.UserName;
            return View(ticket);
        }
    }
}

