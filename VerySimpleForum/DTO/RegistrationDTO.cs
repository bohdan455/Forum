using System.ComponentModel.DataAnnotations;

namespace VerySimpleForum.DTO
{
    public class RegistrationDTO
    {
        [Required(ErrorMessage = "Enter login")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }
        [EmailAddress]
        [Required(ErrorMessage ="Enter email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Repeat password")]
        public string RepeatPassword { get; set; }
    }
}
