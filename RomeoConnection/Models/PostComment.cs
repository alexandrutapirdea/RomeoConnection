using System.ComponentModel.DataAnnotations;

namespace RomeoConnection.Models
{
    public class PostComment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(3000)]
        public string CommentText { get; set; }

        public virtual ApplicationUser CommentBy { get; set; }

        [Required]
        public string CommentById { get; set; }


    }
}