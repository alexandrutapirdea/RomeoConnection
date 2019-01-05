using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace RomeoConnection.Models
{
    public class GroupPost
    {
        public int Id { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [StringLength(254)]
        public string ApplicationUserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(3000)]
        public string Description { get; set; }

        public byte[] PostPicture { get; set; }

        [NotMapped]
        public HttpPostedFileBase GroupPostPicture { get; set; }

        public virtual List<PostComment> Comments { get; set; }

        public Group Group { get; set; }

        [Required]
        public int GroupId { get; set; }
    }
}