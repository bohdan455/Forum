using System.ComponentModel.DataAnnotations;

namespace VerySimpleForum.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="Enter login")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }
    }
}
