using RomeoConnection.Models;
using System.Collections.Generic;

namespace RomeoConnection.ViewModels
{
    public class UserPostsAndCommentsViewModel
    {
        public IEnumerable<UserPost> UserPost { get; set; }
        public PostComment PostComment { get; set; }
        public bool ShowActions { get; set; }
    }
}