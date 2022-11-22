using VerySimpleForum.DataBase;
using VerySimpleForum.DataBase.Models;
using VerySimpleForum.Interfaces;

namespace VerySimpleForum.Controllers
{
    public class LikeAction<ElementType> where ElementType : ILikeable
    {
        private readonly ApplicationDbContext context;

        public LikeAction(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Like(ElementType element,string username)
        {
            var user = context.Users.Where(u => u.UserName == username).FirstOrDefault();
            if (element.Likes == null)
            {
                element.Likes = new List<User>();
            }
            if (element.Likes.Where(u => u.UserName == user.UserName).Any())
            {
                element.Likes.Remove(user);
            }
            else
            {
                element.Likes.Add(user);
            }
            context.SaveChanges();
        }
    }
}
