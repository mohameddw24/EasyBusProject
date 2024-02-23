using EasyBusProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Text.Json;

namespace EasyBusProject.Controllers
{
    public class SeatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public class MyModel
        {
            public Dictionary<string,bool> Data { get; set; }
        }

        [HttpPost]
        public IActionResult Index(CheckBoxViewModel checkBoxViewModel)
        {
            TempData["name"] = "Moe";
            TempData["noOfSeats"] = checkBoxViewModel.CheckboxValues.Count;

            ViewData["seats"] = checkBoxViewModel;
            string json = JsonSerializer.Serialize(checkBoxViewModel);
            TempData["SerializedDictionary"] = json;
            return RedirectToAction("TicketsView");
        }

        public IActionResult TicketsView()
        {
            string name = TempData["name"] as string;
            string json = TempData["SerializedDictionary"] as string;

            CheckBoxViewModel seats = JsonSerializer.Deserialize<CheckBoxViewModel>(json);

            var noOfSeats = TempData["noOfSeats"];

            ViewBag.DataReceived = name;
            ViewBag.NumberOfSeats = noOfSeats;
            ViewBag.Seats = seats.CheckboxValues;
            return View();
        }

    }
}
