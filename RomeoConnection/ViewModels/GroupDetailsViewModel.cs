using RomeoConnection.Models;
using System.Collections.Generic;

namespace RomeoConnection.ViewModels
{
    public class GroupDetailsViewModel
    {
        public Group Group { get; set; }

        public List<GroupPost> GroupPosts { get; set; }

        public GroupPost GroupPost { get; set; }
    }
}