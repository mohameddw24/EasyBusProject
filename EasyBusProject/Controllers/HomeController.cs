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

        public HomeController(ILogger<HomeController> logger, StationRepoServices station)
        {
            _logger = logger;
            StationRepoServices = station;
        }

        public IActionResult Index()
        {
            ViewBag.Stations = StationRepoServices.GetAll();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
