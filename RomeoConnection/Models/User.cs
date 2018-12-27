using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RomeoConnection.Models
{
    public class User
    {
        public String firstName { get; set; }
        public String lastName { get; set; }

        public String location { get; set; }

        public String description { get; set; }

        public String job { get; set; }

        public List<User> friendsList { get; set; }

        public byte age { get; set; }

        public Boolean isPublicProfile { get; set; }
    }
}