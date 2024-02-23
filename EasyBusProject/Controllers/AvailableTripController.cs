using EasyBus.Models;
using EasyBusProject.RepoServices;
using EasyBusProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using System.Net.Sockets;
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

        public IActionResult ChooseTrip(int id, string date, int NumOfSeatsOfUser)
        {
            var trip = _contextTrip.GetAll().Where(t => t.Id == id).FirstOrDefault();
            var scheduleTrips = _contextSchedule.GetAll().Where(s => s.TripId == id).FirstOrDefault();
            var userSchedule = new UserSchedule();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            userSchedule.UserId = int.Parse(userId);
            if ((int)trip.Bus.Seats - _contextUserSchedule.GetAvailableSeats(scheduleTrips.Id) < NumOfSeatsOfUser)
            {
                ModelState.AddModelError("Error", "Add valid Number of seats");
                return RedirectToAction("DetailsOfTrip",new { id = id, date = date});

            }

            if (scheduleTrips != null)
            {
                userSchedule.ScheduleId = scheduleTrips.Id;
                userSchedule.NumOfSeats = NumOfSeatsOfUser;
                _contextUserSchedule.Add(userSchedule);
                scheduleTrips.AvailableSeatsInTrip = (int)trip.Bus.Seats - _contextUserSchedule.GetAvailableSeats(scheduleTrips.Id);
                _contextSchedule.Update(scheduleTrips);
                return View("Schedule", scheduleTrips);
                //return RedirectToAction(nameof(DetailsOfTrip), scheduleTrips);
            }
            else
            {
                var newSchedule = new Schedule
                {
                    TripId = id,
                    Date = DateOnly.Parse(date),
                    AvailableSeatsInTrip = (int)trip.Bus.Seats - _contextUserSchedule.GetAvailableSeats(scheduleTrips.Id)
                };
                _contextSchedule.Add(newSchedule);

                userSchedule.ScheduleId = newSchedule.Id;
            }

            _contextUserSchedule.Add(userSchedule);
            return View(trip);
        }

        public IActionResult DetailsOfTrip(int id, string date)
        {
            var trip = _contextTrip.GetAll().Where(t => t.Id == id).FirstOrDefault();
            var scheduleTrips = _contextSchedule.GetAll().Where(s => s.TripId == id).FirstOrDefault();
            var user = User.FindFirstValue(ClaimTypes.Name);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ticket = new DetailsOfReservedTripVM();
            ViewBag.tripId = id;


            if (scheduleTrips != null)
            {
                ticket.UserName = user;
                ticket.BusName = trip.Bus.Model;
                ticket.Price = (int)trip.Price;
                ticket.Date = DateOnly.Parse(date);
                ticket.StartFrom = trip.PickUp.Name;
                ticket.Destination = trip.DropOff.Name;
                ticket.Time = trip.Time;
                ticket.NumOfAvailSeats = scheduleTrips.AvailableSeats;
                
            }

            return View(ticket);
        }

    }
}

