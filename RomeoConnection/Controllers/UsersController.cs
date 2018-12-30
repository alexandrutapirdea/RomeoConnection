using RomeoConnection.Models;
using RomeoConnection.ViewModels;
using System.Collections.Generic;
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
        private IEnumerable<User> GetUsers()
        {
            var listOfApplicationUsers = _context.Users;
            var listOfUsers = new List<User>();

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


                listOfUsers.Add(temporaryUser);

            }
            return listOfUsers;
        }
    }
}