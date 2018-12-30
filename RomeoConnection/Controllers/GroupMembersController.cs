using Microsoft.AspNet.Identity;
using RomeoConnection.Dtos;
using RomeoConnection.Models;
using System.Linq;
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

        //Cand verifici cu postman trebuie sa trimiti un obiect de tipul 
        // { "GroupId" ="3"(ca string)} 
        // daca trimiti direct un numar valoarea este null ( pentru ca astepata
        // obiect si i-ai trimis int )
        [HttpPost]
        public IHttpActionResult GroupMember(GroupMembersDto dto)
        {
            var userId = User.Identity.GetUserId();
            var exists = _context.GroupMembers
                .Any(m => m.GroupMemberUserId == userId
                     && m.GroupId == dto.GroupId);

            if (exists)
                return BadRequest("You are already a member of this group");

            var member = new GroupMember()
            {
                GroupId = dto.GroupId,
                GroupMemberUserId = userId,
            };
            _context.GroupMembers.Add(member);
            _context.SaveChanges();

            return Ok();
        }


    }
}
