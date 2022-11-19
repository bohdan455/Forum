using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VerySimpleForum.DataBase;
using VerySimpleForum.DataBase.Models;

namespace VerySimpleForum.Pages.SubTopicPages
{
    public class CommentActionModel : PageModel
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<CommentActionModel> logger;

        public CommentActionModel(ApplicationDbContext context, ILogger<CommentActionModel> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [Authorize]
        public IActionResult OnPost(string title, string body)
        {
            var subTopic = context.SubTopics.Where(s => s.Title == title).FirstOrDefault();
            if(subTopic.Comments == null)
            {
                subTopic.Comments = new List<Comment>();
            }
            if (ModelState.IsValid)
            {
                logger.LogInformation("Super informative {body}", body);
            }
            else
            {
                logger.LogError("ERROR");
            }
            return RedirectToPage("/SubTopicPages/SubTopicPage", new { title = title });
        }
    }
}
