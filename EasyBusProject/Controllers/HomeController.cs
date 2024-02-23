using EasyBus.Models;
using EasyBusProject.Models;
using EasyBusProject.RepoServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EasyBusProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public StationRepoServices StationRepoServices { get; set; }
        public ContactUsRepoService ContactUsRepoServices { get; set; }

        public HomeController(ILogger<HomeController> logger, 
            StationRepoServices station,
            ContactUsRepoService contact)
        {
            _logger = logger;
            StationRepoServices = station;
            ContactUsRepoServices = contact;
        }

        public IActionResult Index()
        {
            ViewBag.Stations = StationRepoServices.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(ContactUs form)
        {
            ContactUsRepoServices.Add(form);
            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou() 
        {
            return View();
        }

        public IActionResult Destinations()
        {
            ViewBag.Stations = StationRepoServices.GetAll();
            return View();
        }

        public IActionResult Destination(int id)
        {
            ViewBag.Station = StationRepoServices.Details(id);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
