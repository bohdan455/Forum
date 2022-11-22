using System.ComponentModel.DataAnnotations;
using VerySimpleForum.Interfaces;

namespace VerySimpleForum.DataBase.Models
{
    public class SubTopic : ILikeable
    {
        public int Id { get; set; }
        [MaxLength(400)]
        public string Title { get; set; }
        public string Body { get; set; }
        public  ICollection<User> Likes { get; set;}
        public User Creator { get; set; }
        public DateTime Created { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
