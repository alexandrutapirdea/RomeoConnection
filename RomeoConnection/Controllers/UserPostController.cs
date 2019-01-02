using Microsoft.AspNet.Identity;
using RomeoConnection.Models;
using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace RomeoConnection.Controllers
{
    public class UserPostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserPostController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: UserPost
        [Authorize]
        public ActionResult CreatePost()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(UserPost createdPost)
        {
            ModelState.Remove("ApplicationUserId");
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            Debug.WriteLine(errors);

            if (!ModelState.IsValid)
            {
                Debug.WriteLine(!ModelState.IsValid);
                return View("CreatePost", createdPost);
            }

            var userId = User.Identity.GetUserId();
            var currentUser = _context.Users.Single(u => u.Id == userId);

            byte[] data = null;
            try
            {
                data = new byte[createdPost.UserPostPicture.ContentLength];
                createdPost.UserPostPicture.InputStream.Read(data, 0, createdPost.UserPostPicture.ContentLength);
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Problema este : {0} ", exception.Message);
            }
            var newPost = new UserPost()
            {

                ApplicationUser = currentUser,
                ApplicationUserId = currentUser.Id,
                Title = createdPost.Title,
                Description = createdPost.Description,
                PostPicture = data,
                //                Users = new List<ApplicationUser>() { currentUser }
            };

            try
            {
                _context.UserPostsList.Add(newPost);
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

            return RedirectToAction("Index", "Home");
        }
    }
}