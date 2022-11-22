using System.ComponentModel.DataAnnotations;
using VerySimpleForum.Interfaces;

namespace VerySimpleForum.DataBase.Models
{
    
    public class Comment : ILikeable
    {
        public int Id { get; set; }
        [Required]
        public User BelongsTo { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Body { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        public ICollection<User> Likes { get; set; }
    }
}
