using Microsoft.AspNet.Identity.EntityFramework;
using RomeoConnection.ViewModels;
using System.Data.Entity;

namespace RomeoConnection.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<User> UsersList { get; set; }
        public DbSet<Group> GroupList { get; set; }

        public DbSet<UserPost> UserPostsList { get; set; }

        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Following> Followings { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupMember>()
                .HasRequired(g => g.Group)
                .WithMany() // later : m=> m.Member si sa adaug Member cu alt enter
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<Following>(u => u.Followers)
                .WithRequired(f => f.Followee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<Following>(u => u.Followees)
                .WithRequired(f => f.Follower)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}