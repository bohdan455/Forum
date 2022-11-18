using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VerySimpleForum.DataBase;
using VerySimpleForum.DataBase.Models;

namespace VerySimpleForum.Pages.SubTopicPages
{
    [Authorize]
    public class LikeAction : PageModel
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<LikeAction> logger;

        public LikeAction(ApplicationDbContext context, ILogger<LikeAction> logger)
        {
            this.context = context;
            this.logger = logger;
        }



        public IActionResult OnPost(string title)
        {
            var subTopic = context.SubTopics.Where(st => st.Title == title).FirstOrDefault();
            var user = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null || subTopic == null) return RedirectToPage("/index");

            if(subTopic.Likes == null)
            {
                subTopic.Likes = new List<User>();
            }
            if(subTopic.Likes.Where(user => user.Id == user.Id).Any())
            {
                subTopic.LikesNumber--;
                logger.LogInformation("remove like");
                subTopic.Likes.Remove(user);
            }
            else
            {
                subTopic.LikesNumber++;
                logger.LogInformation("add like");
                subTopic.Likes.Add(user);
            }
            context.SaveChanges();
            return RedirectToPage("/subTopicPages/SubTopicPage", new {title = title});
        }
    }
}
