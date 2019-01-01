using Microsoft.AspNet.Identity;
using RomeoConnection.Models;
using RomeoConnection.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RomeoConnection.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Users
        public ActionResult Index()
        {
            var users = GetUsers();

            var usersViewModel = new UserViewModel()
            {
                Users = users,
                ShowActions = User.Identity.IsAuthenticated
            };

            return View(usersViewModel);
        }

        [Authorize]
        public ActionResult MyFriends()
        {
            var userId = User.Identity.GetUserId();
            var friends = _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();
            //Daca primesti null pointer exception trebuie sa adaugi Include(ceva => ceva.altceva),
            // unde ceva si altceva sunt proprietatile din alte tabele ( de exemplu pentru calendar)
            var viewModel = new UserViewModel()
            {
                Users = ApplicationUsersToUsersList(friends),
                ShowActions = User.Identity.IsAuthenticated
            };
            return View(viewModel);

        }


        private IEnumerable<User> GetUsers()
        {
            var listOfApplicationUsers = _context.Users
                                         .Where(u => u.IsPrivateProfile == false)
                                         .ToList();

            return ApplicationUsersToUsersList(listOfApplicationUsers);
        }

        private IEnumerable<User> ApplicationUsersToUsersList(List<ApplicationUser> listOfApplicationUsers)
        {
            var listOfUsers = new List<User>();

            // map ApplicationUser to User ( remove additional info such as email or password )
            foreach (var user in listOfApplicationUsers)
            {
                var temporaryUser = new User();
                temporaryUser.Description = user.Description;
                temporaryUser.Birthday = user.BirthDay;
                temporaryUser.FirstName = user.FirstName;
                temporaryUser.LastName = user.LastName;
                temporaryUser.JobTitle = user.JobTitle;
                temporaryUser.Location = user.Location;
                temporaryUser.DisplayId = user.Id;
                temporaryUser.ProfilePicture = user.ProfilePicture;
                temporaryUser.IsPrivateProfile = user.IsPrivateProfile;


                listOfUsers.Add(temporaryUser);

            }
            return listOfUsers;
        }

    }
}