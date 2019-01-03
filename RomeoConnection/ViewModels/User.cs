using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace RomeoConnection.ViewModels
{
    public class User
    {
        public int Id { get; set; }

        public string DisplayId { get; set; }

        public string ImagePath { get; set; }

        [Required]
        [StringLength(254)]
        public String FirstName { get; set; }

        [Required]
        [StringLength(254)]
        public String LastName { get; set; }

        public String Location { get; set; }

        public String Description { get; set; }

        public String JobTitle { get; set; }

        public String Birthday { get; set; }

        public List<User> friendsList { get; set; }

        public byte Age { get; set; }

        public Boolean IsPrivateProfile { get; set; }

        public byte[] ProfilePicture { get; set; }

        [NotMapped]
        public HttpPostedFileBase UserProfilePicture { get; set; }

        public string UserRole { get; set; }



    }
}