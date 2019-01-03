using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RomeoConnection.Models;

[assembly: OwinStartupAttribute(typeof(RomeoConnection.Startup))]
namespace RomeoConnection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRoles();
        }

        private void createRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new
                RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new
                UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("RegularUser"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "RegularUser";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.FirstName = "Thor";
                user.LastName = "Thor";
                user.UserRole = "Admin";
                user.Email = "thor@thor.com";
                user.UserName = "thor@thor.com";
                var adminCreated = UserManager.Create(user, "!Parola20192019");
                if (adminCreated.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Admin");
                }
            }

        }
    }
}

