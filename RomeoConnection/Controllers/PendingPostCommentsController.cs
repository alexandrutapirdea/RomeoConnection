using Microsoft.AspNet.Identity;
using RomeoConnection.Dtos;
using RomeoConnection.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace RomeoConnection.Controllers
{
    public class PendingPostCommentsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public PendingPostCommentsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult PendingPostComment(PendingPostComment dto)
        {
            var userId = User.Identity.GetUserId();
            var postId = Int32.Parse(dto.postComment);
            var postComment = _context.PostComments.Where(p => p.Id == postId).FirstOrDefault();

            if (postComment.CommentStatus != "declined")
            {
                if (postComment.CommentStatus == "approved")
                {
                    return BadRequest("Comment already approved");
                }
                else
                {
                    postComment.CommentStatus = "approved";
                    _context.SaveChanges();
                }
            }
            else
            {
                return BadRequest("Comment DECLINED");
            }

            return Ok();

        }

        //De facut ca mai sus
        //        public IHttpActionResult DeclinePostComment(PostComment model)
        //        {
        //            var userId = User.Identity.GetUserId();
        //            model.CommentStatus = "declined";
        //            _context.SaveChanges();
        //
        //            return Ok();
        //        }
    }
}
