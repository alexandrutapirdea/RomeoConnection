using Microsoft.AspNet.Identity;
using RomeoConnection.Models;
using RomeoConnection.ViewModels;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace RomeoConnection.Controllers
{
    public class GroupPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupPostsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult CreateGroupPost(GroupDetailsViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var currentUser = _context.Users.Single(u => u.Id == userId);

            var groupPost = new GroupPost
            {
                GroupId = model.Group.Id,
                ApplicationUser = currentUser,
                ApplicationUserId = userId,
                Title = model.GroupPost.Title,
                Description = model.GroupPost.Description
            };
            try
            {
                _context.GroupPosts.Add(groupPost);
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

            return RedirectToAction("GroupDetails", "Groups", new { id = groupPost.GroupId });
        }
    }
}