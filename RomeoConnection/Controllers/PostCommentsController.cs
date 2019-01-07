using Microsoft.AspNet.Identity;
using RomeoConnection.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace RomeoConnection.Controllers
{
    public class PostCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostCommentsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public ActionResult CreatePostComment(PostComment createdComment)
        {


            ModelState.Remove("CommentById");

            var userId = User.Identity.GetUserId();
            var currentUser = _context.Users.Single(u => u.Id == userId);

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            Debug.WriteLine(errors);

            var newComment = new PostComment
            {
                CommentText = createdComment.CommentText,
                CommentBy = currentUser,
                CommentById = userId,
                UserPostId = createdComment.UserPostId,
                CommentStatus = "pending"
            };
            try
            {
                _context.PostComments.Add(newComment);
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

            var selectedPost = _context.UserPostsList.Where(u => u.Id == createdComment.UserPostId);

            selectedPost.ToList().FirstOrDefault().Comments.Add(newComment);
            _context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }
    }
}