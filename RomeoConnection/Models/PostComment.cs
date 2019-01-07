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

        public UserPost UserPost { get; set; }

        public int UserPostId { get; set; }

        public string CommentStatus { get; set; }



    }
}