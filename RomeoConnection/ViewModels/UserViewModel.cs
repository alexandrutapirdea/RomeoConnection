using System;
using System.Collections.Generic;

namespace RomeoConnection.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public Boolean ShowActions { get; set; }
    }
}