using System.ComponentModel.DataAnnotations;

namespace InfasLogin.Models
{
    public class User
    {
        [Required(ErrorMessage ="Username is requied")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Username is requied")]
        public string Password { get; set; }
    }
}
