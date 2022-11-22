using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VerySimpleForum.Controllers;
using VerySimpleForum.DataBase;
using VerySimpleForum.DataBase.Models;

namespace VerySimpleForum.Pages.SubTopicPages
{
    public class CommentLikeModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public CommentLikeModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void OnPost(int id)
        {
            var comment = context.Comments.Where(c => c.Id == id).FirstOrDefault();
            var Like = new LikeAction<Comment>(context);
            Like.Like(comment, User.Identity.Name);
        }
    }
}
