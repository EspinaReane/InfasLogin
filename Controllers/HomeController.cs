using System.Diagnostics;
using InfasLogin.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfasLogin.Controllers
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
            // Check if the user is logged in by checking the session
            if (HttpContext.Session.GetString("Username") == null)
            {
                // Redirect to login page if no session is found
                return RedirectToAction("Login", "Login");
            }

            // Continue with the usual Home page if the user is logged in
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
