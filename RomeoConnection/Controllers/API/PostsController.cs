using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RomeoConnection.Models;

namespace RomeoConnection.Controllers.API
{
    public class PostsController : ApiController
    {
        private ApplicationDbContext _context;

        public PostsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var deletedPost = _context.UserPostsList.Where(p => p.Id == id).FirstOrDefault();
            deletedPost.IsDeleted = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
