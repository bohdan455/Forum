using System.ComponentModel.DataAnnotations;

namespace VerySimpleForum.DataBase.Models
{
    
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public User BelongsTo { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Body { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
    }
}
