using RomeoConnection.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RomeoConnection.Controllers
{
    public class GroupsController : Controller
    {
        // GET: Groups
        public ActionResult Index()
        {
            var groups = GetGroups();

            return View(groups);
        }

        public ActionResult CreateGroup()
        {

            return View();
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