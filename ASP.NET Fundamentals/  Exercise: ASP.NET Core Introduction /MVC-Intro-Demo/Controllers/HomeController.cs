using Microsoft.AspNetCore.Mvc;
using MVC_Intro_Demo.Models;
using System.Diagnostics;

namespace MVC_Intro_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Home";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About() 
        {
            ViewBag.Message = "About";
            return View();
        }

        [HttpGet]
        public IActionResult NumbersToN()
        {
            ViewBag.Count = -1;
            return View();
        }

        [HttpPost]
        public IActionResult NumbersToN(int count = -1)
        {
            ViewBag.Count = count;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}