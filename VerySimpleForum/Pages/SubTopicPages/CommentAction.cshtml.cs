using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VerySimpleForum.DataBase;
using VerySimpleForum.DataBase.Models;
using VerySimpleForum.DTO;

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
        public IActionResult OnPost(string title,CommentDTO comment)
        {
            logger.LogInformation("Commention data is {Body}", comment.Body);
            logger.LogInformation("Title is {title}", title);
            var subTopic = context.SubTopics.Where(s => s.Title == title).FirstOrDefault();
            var user = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if(subTopic.Comments == null)
            {
                subTopic.Comments = new List<Comment>();
            }
            subTopic.Comments.Add(new Comment
            {
                BelongsTo = user,
                Body = comment.Body,
                CreatedTime = DateTime.Now,
            });
            context.SaveChanges();
            return RedirectToPage("/SubTopicPages/SubTopicPage", new { title = title });
        }
    }
}
