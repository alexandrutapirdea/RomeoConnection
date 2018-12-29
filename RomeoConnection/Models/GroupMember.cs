using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RomeoConnection.Models
{
    public class GroupMember
    {
        public Group Group { get; set; }
        public ApplicationUser GroupMemberUser { get; set; }

        [Key]
        [Column(Order = 1)]
        public int GroupId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string GroupMemberUserId { get; set; }
    }
}