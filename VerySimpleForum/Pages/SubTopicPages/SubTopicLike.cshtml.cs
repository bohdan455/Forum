using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VerySimpleForum.DataBase;
using VerySimpleForum.DataBase.Models;

namespace VerySimpleForum.Pages.SubTopicPages
{
    [Authorize]
    public class SubTopicLike : PageModel
    {
        private readonly ApplicationDbContext context;

        public SubTopicLike(ApplicationDbContext context)
        {
            this.context = context;
        }



        public IActionResult OnPost(string title)
        {
            var subTopic = context.SubTopics.Where(st => st.Title == title).FirstOrDefault();
            var Like = new Controllers.LikeAction<SubTopic>(context);
            Like.Like(subTopic, User.Identity.Name);
            return RedirectToPage("/subTopicPages/SubTopicPage", new {title = title});
        }
    }
}
