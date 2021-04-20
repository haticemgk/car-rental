using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {//IOC = Inversion of Control
        //Dependency Injection
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleBrandService _service;

        public HomeController(ILogger<HomeController> logger,IVehicleBrandService vehicleBrandService)
        {
            _logger = logger;
            _service = vehicleBrandService;
        }

        public IActionResult Index()
        {
            
            string serviceName = _service.GetName();
            ViewBag.ServiceName = serviceName;
            return View();
        }

        public IActionResult Privacy()
        {
            
            string serviceName = _service.GetName();
            ViewBag.ServiceName = serviceName;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
