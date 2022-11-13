using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using VerySimpleForum.DTO;
using VerySimpleForum.DataBase.Models;
using Microsoft.AspNetCore.Identity;

namespace VerySimpleForum.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> signInManager;

        public LoginModel(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }

        [BindProperty]
        public LoginDTO Login { get; set; }
        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var result = await signInManager.PasswordSignInAsync(Login.UserName, Login.Password, true, true);
            if (result.Succeeded)
            {
                return RedirectToPage("/index");
            }
            else
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("Login","You are locked out");
                }
                else
                {
                    ModelState.AddModelError("Login", "Password or login is wrong");
                }
                return Page();
            }
        }
    }
}
