using ITIMVCD1.Models;
using ITIMVCD2.CustomActionFilter;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITIMVCD1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ExceptionFilter]
        public IActionResult Index()
        {
            int x = int.Parse("Ad");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
