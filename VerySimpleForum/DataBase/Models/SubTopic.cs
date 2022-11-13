namespace VerySimpleForum.DataBase.Models
{
    public class SubTopic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public  ICollection<User> Likes { get; set;}
        public User Creator { get; set; }
        public DateTime Created { get; set; }

    }
}
