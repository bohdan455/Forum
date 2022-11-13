using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VerySimpleForum.DataBase;
using VerySimpleForum.DataBase.Models;

namespace VerySimpleForum.Pages.SubTopicPages
{
    public class SubTopicPageModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public SubTopicPageModel(ApplicationDbContext context, ILogger<SubTopicPageModel> logger)
        {
            this.context = context;
            Logger = logger;
        }

        [BindProperty]
        public SubTopic SubTopic { get; set; }

        public ILogger Logger { get; }
        public IActionResult OnGet(string title)
        {
            Logger.LogInformation("GET");
            SubTopic = context.SubTopics.Where(SubTopic => SubTopic.Title == title).FirstOrDefault();
            if (SubTopic == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public void like()
        {
            Logger.LogInformation("Click");
            /*            var user = context.Users.Where(user => user.UserName == User.Identity.Name).FirstOrDefault();
                        if (context.SubTopics.Where(subTopic => subTopic.Likes.Contains(user)).Any()){

                        }*/
        }
    }
}
