using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using VerySimpleForum.DataBase;
using VerySimpleForum.DataBase.Models;
using VerySimpleForum.DTO;

namespace VerySimpleForum.Pages.SubTopicPages
{
    public class SubTopicFormModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public SubTopicFormModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        [Required]
        [BindProperty]
        public SubTopicDTO SubTopicData { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            SubTopic subTopic = new SubTopic
            {

                Title = SubTopicData.Title,
                Body = SubTopicData.Body,
                Creator = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault(),
                Created = DateTime.Now,
            };
            context.SubTopics.Add(subTopic);
            await context.SaveChangesAsync();
            return RedirectToPage("/SubTopicPages/SubTopicPage", new {title = subTopic.Title});
        } 
    }
}
