using VerySimpleForum.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VerySimpleForum.DTO;
using Microsoft.AspNetCore.Identity;

namespace VerySimpleForum.Pages.Account
{
    public class RegistrationModel : PageModel
    {
        public RegistrationModel(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        [BindProperty]
        public RegistrationDTO Registration { get; set; }
        private readonly UserManager<User> userManager;

        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            if(Registration.Password != Registration.RepeatPassword)
            {
                ModelState.AddModelError("Password","Passwords should be the same");
                return Page();
            }
            var user = new User
            {
                UserName = Registration.UserName,
                Email = Registration.Email
            };
            var result = await userManager.CreateAsync(user, Registration.Password);
            if (result.Succeeded)
            {
                return RedirectToPage("/account/login");
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("Registration", error.Description);
                }
                return Page();
            }
        }
        
    }
}
