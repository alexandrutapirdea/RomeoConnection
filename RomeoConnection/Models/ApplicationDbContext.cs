using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using RomeoConnection.ViewModels;

namespace RomeoConnection.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> UsersList { get; set; }
        public DbSet<Group> GroupList { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}