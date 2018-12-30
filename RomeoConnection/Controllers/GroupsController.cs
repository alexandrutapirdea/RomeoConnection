using Microsoft.AspNet.Identity;
using RomeoConnection.Models;
using RomeoConnection.ViewModels;
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

        [Authorize]
        public ActionResult MyGroups()
        {
            var userId = User.Identity.GetUserId();
            var groups = _context.GroupMembers
                .Where(m => m.GroupMemberUserId == userId)
                .Select(g => g.Group)
                .ToList();
            //Daca primesti null pointer exception trebuie sa adaugi Include(ceva => ceva.altceva),
            // unde ceva si altceva sunt proprietatile din alte tabele ( de exemplu pentru calendar)
            var viewModel = new GroupViewModel()
            {
                Groups = groups,
                ShowActions = User.Identity.IsAuthenticated
            };
            return View(viewModel);

        }

        public GroupsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Groups
        public ActionResult Index()
        {
            var groups = GetGroups();

            var viewModel = new GroupViewModel
            {
                Groups = groups,
                ShowActions = User.Identity.IsAuthenticated,
            };

            return View(viewModel);
        }
        [Authorize]
        public ActionResult CreateGroup()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGroup(Group createdGroup)
        {
            ModelState.Remove("CreatedById");
            //            var errors = ModelState.Values.SelectMany(v => v.Errors);
            //            Debug.WriteLine(errors);
            if (!ModelState.IsValid)
            {
                //                Debug.WriteLine(!ModelState.IsValid);
                return View("CreateGroup", createdGroup);
            }
            var userId = User.Identity.GetUserId();
            var currentUser = _context.Users.Single(u => u.Id == userId);
            var newGroup = new Group
            {
                CreatedBy = currentUser,
                CreatedById = currentUser.Id,
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

            return _context.GroupList;
        }
    }
}