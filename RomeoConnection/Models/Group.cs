using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RomeoConnection.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required]
        [StringLength(254)]
        public String Title { get; set; }


        [Required]
        [StringLength(3000)]
        public String Description { get; set; }

        public int NumberOfUsers { get; set; }

        public List<ApplicationUser> Users { get; set; }

        [Required]
        public string CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; }

        //DE INLOCUIT APPLICATIONUSER CU USER

        public int NrUsers { get; set; }
    }
}