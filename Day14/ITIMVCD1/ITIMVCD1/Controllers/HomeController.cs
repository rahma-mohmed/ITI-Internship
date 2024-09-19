using ITIMVCD1.Models;
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

        public IActionResult Index()
        {
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

            [HttpPost]
            public IActionResult ChangeCulture(string culture)
            {
                Response.Cookies.Append("culture", culture, new CookieOptions { Expires = DateTime.Now.AddHours(1) });
                return RedirectToAction("Index");
            }
    }
}
