using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RomeoConnection.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(254)]
        public String firstName { get; set; }

        [Required]
        [StringLength(254)]
        public String lastName { get; set; }

        public String location { get; set; }

        public String description { get; set; }

        public String job { get; set; }

        public List<User> friendsList { get; set; }

        public byte age { get; set; }

        public Boolean isPublicProfile { get; set; }
    }
}