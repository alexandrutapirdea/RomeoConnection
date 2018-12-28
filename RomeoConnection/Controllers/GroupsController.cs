using Microsoft.AspNet.Identity;
using RomeoConnection.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RomeoConnection.Controllers
{
    public class GroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Groups
        public ActionResult Index()
        {
            var groups = GetGroups();

            return View(groups);
        }
        [Authorize]
        public ActionResult CreateGroup()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateGroup(Group createdGroup)
        {
            var userId = User.Identity.GetUserId();
            var fakeUser = _context.Users.Single(u => u.Id == userId);
            //            var fakeUser = _context.Users.Single(u => u.Id == "3");
            var newGroup = new Group
            {
                CreatedBy = fakeUser,
                Title = createdGroup.Title,
                Description = createdGroup.Description,
                NumberOfUsers = 1,
                Users = new List<ApplicationUser>() { fakeUser }
            };

            _context.GroupList.Add(newGroup);
            _context.SaveChanges();

            return RedirectToAction("Index", "Groups");
        }

        private IEnumerable<Group> GetGroups()
        {
            return new List<Group>
            {
                new Group { Title = "Group de pisici", Description = "Giumanca iubieste pufoseniile" },
                new Group { Title = "Alex Cojocaru", Description = "Tea party at 16:20" },
            };
        }
    }
}