using RomeoConnection.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RomeoConnection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var groups = GetPosts();
            return View(groups);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private IEnumerable<UserPost> GetPosts()
        {

            return _context.UserPostsList;

        }



    }
}