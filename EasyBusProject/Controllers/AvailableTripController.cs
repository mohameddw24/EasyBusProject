using EasyBus.Models;
using EasyBusProject.RepoServices;
using EasyBusProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace EasyBusProject.Controllers
{
    public class AvailableTripController : Controller
    {
        private readonly IRepository<Trip> _contextTrip;
        private readonly IRepository<Schedule> _contextSchedule;
        private readonly UserScheduleRepoServices _contextUserSchedule;

        public AvailableTripController(IRepository<Trip> contextTrip, IRepository<Schedule> contextSchedule, UserScheduleRepoServices contextUserSchedule)
        {
            _contextTrip = contextTrip;
            _contextSchedule = contextSchedule;
            _contextUserSchedule = contextUserSchedule;
        }

        private DateOnly _dateOnly { get; set; }
        public IActionResult Index(int pickUp, int dropOff, DateOnly date)
        {
            _dateOnly = date;
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
            var user = User.FindFirstValue(ClaimTypes.Name);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ticket = new DetailsOfReservedTripVM();
            ViewBag.SeatsTaken = scheduleTrips?.NumOfSeatsReserved?.Split(", ") ?? new string[0];

            ViewBag.tripId = id;

            ticket.UserName = user;
            ticket.BusName = trip.Bus.Model;
            ticket.Price = (int)trip.Price;
            ticket.Date = DateOnly.Parse(date);
            ticket.StartFrom = trip.PickUp.Name;
            ticket.Destination = trip.DropOff.Name;
            ticket.Time = trip.Time;
            ticket.NumOfAvailSeats = scheduleTrips?.AvailableSeats ?? (int)trip.Bus.Seats;
            ticket.TotalCapacity = (int)trip.Bus.Seats;


            return View(ticket);
        }

        [HttpPost]
        public IActionResult DetailsOfTrip(int id, string date, CheckBoxViewModel checkBoxViewModel, DetailsOfReservedTripVM ticket)
        {
            ticket.NumOfSeatsOfUser = checkBoxViewModel.CheckboxValues.Count;
            var trip = _contextTrip.GetAll().Where(t => t.Id == id).FirstOrDefault();
            var scheduleTrips = _contextSchedule.GetAll().Where(s => s.TripId == id && s.Date == DateOnly.Parse(date)).FirstOrDefault();
            string[] checkedIdsAsStrings = checkBoxViewModel.CheckboxValues.Keys.Select(k => k.ToString()).ToArray();
            string joinedCheckedIds = String.Join(", ", checkedIdsAsStrings);


            var userSchedule = new UserSchedule();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            userSchedule.UserId = int.Parse(userId);

            if (!ModelState.IsValid)
            {
                return View(ticket);
            }
            else
            {
                if (scheduleTrips != null)
                {
                    scheduleTrips.NumOfSeatsReserved += ", " + joinedCheckedIds;
                    userSchedule.ScheduleId = scheduleTrips.Id;
                    userSchedule.NumOfSeats = ticket.NumOfSeatsOfUser;
                    userSchedule.SeatsTaken = joinedCheckedIds;
                    _contextUserSchedule.Add(userSchedule);
                    scheduleTrips.AvailableSeatsInTrip = (int)trip.Bus.Seats - _contextUserSchedule.GetAvailableSeats(scheduleTrips.Id);
                    _contextSchedule.Update(scheduleTrips);
                    return Content("scheduleTrips Updated");
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
                }
                _contextUserSchedule.Add(userSchedule);
                return Content("Done...");
            }
        }

    }
}

