using InfasLogin.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfasLogin.Controllers
{
    public class LoginController : Controller
    {
        private const string HardcodedUsername = "user";
        private const string HardcodedPassword = "password";

        public IActionResult Login()
        {
            // Check if already logged in
            if (HttpContext.Session.GetString("Username") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (user.Username == HardcodedUsername && user.Password == HardcodedPassword)
            {
                // Set session if login is successful
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
