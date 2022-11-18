using System.ComponentModel.DataAnnotations;

namespace VerySimpleForum.DTO
{
    public class CommentDTO
    {
        [Required]
        public string Body { get; set; }
    }
}
