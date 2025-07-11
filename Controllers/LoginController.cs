using InfasLogin.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfasLogin.Controllers
{
    public class LoginController : Controller
    {
        // Simulated user credentials (insecure)
        private const string HardcodedUsername = "user";
        private const string HardcodedPassword = "password";

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (user.Username == HardcodedUsername && user.Password == HardcodedPassword)
            {
                // Set session
                HttpContext.Session.SetString("Username", user.Username);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid username or password.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
