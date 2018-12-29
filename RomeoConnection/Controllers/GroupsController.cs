using Microsoft.AspNet.Identity;
using RomeoConnection.Models;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
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
            var currentUser = _context.Users.Single(u => u.Id == userId);
            var newGroup = new Group
            {
                CreatedBy = currentUser,
                CreadtedById = currentUser.Id,
                Title = createdGroup.Title,
                Description = createdGroup.Description,
                NumberOfUsers = 1,
                Users = new List<ApplicationUser>() { currentUser }
            };



            try
            {
                _context.GroupList.Add(newGroup);
                _context.SaveChanges();
                Debug.WriteLine("Felicitari Jordi");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Debug.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

            return RedirectToAction("Index", "Groups");
        }

        private IEnumerable<Group> GetGroups()
        {
            Debug.WriteLine(_context.GroupList);
            //            return new List<Group>
            //            {
            //                new Group { Title = "Group de pisici", Description = "Giumanca iubieste pufoseniile" },
            //                new Group { Title = "Alex Cojocaru", Description = "Tea party at 16:20" },
            //            };
            return _context.GroupList;
        }
    }
}