using RomeoConnection.Models;
using RomeoConnection.ViewModels;
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
            var posts = GetPosts();

            var viewModel = new UserPostsAndCommentsViewModel
            {
                UserPost = posts,
                PostComment = new PostComment { }
            };

            return View(viewModel);
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