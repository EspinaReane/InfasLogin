using InfasLogin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient; // Use System.Data.SqlClient for .NET Framework
using Microsoft.Extensions.Configuration;

namespace InfasLogin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Vulnerable SQL query (unsafe, for demonstration only)
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            string sql = $"SELECT * FROM Users WHERE Username = '{user.Username}' AND Password = '{user.Password}'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    HttpContext.Session.SetString("Username", user.Username);
                    return RedirectToAction("Index", "Home");
                }
                reader.Close();
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