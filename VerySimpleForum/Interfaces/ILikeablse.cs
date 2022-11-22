using VerySimpleForum.DataBase.Models;

namespace VerySimpleForum.Interfaces
{
    public interface ILikeable
    {
        public ICollection<User> Likes { get; set; }
    }
}
