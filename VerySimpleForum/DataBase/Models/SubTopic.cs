using System.ComponentModel.DataAnnotations;

namespace VerySimpleForum.DataBase.Models
{
    public class SubTopic
    {
        public int Id { get; set; }
        [MaxLength(400)]
        public string Title { get; set; }
        public string Body { get; set; }
        public  ICollection<User> Likes { get; set;}
        public int LikesNumber {get; set;} = 0;
        public User Creator { get; set; }
        public DateTime Created { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
