using Microsoft.AspNet.Identity;
using RomeoConnection.Models;
using System.Web.Http;

namespace RomeoConnection.Controllers
{
    [Authorize]
    public class GroupMembersController : ApiController
    {
        private ApplicationDbContext _context;

        public GroupMembersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult GroupMember([FromBody]int groupId)
        {
            var member = new GroupMember()
            {
                GroupId = groupId,
                GroupMemberUserId = User.Identity.GetUserId(),
            };
            _context.GroupMembers.Add(member);
            _context.SaveChanges();

            return Ok();
        }
    }
}
