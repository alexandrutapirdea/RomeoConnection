using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RomeoConnection.Models;

namespace RomeoConnection.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            var user = GetUsers();

            return View(user);
        }
        private IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User { firstName ="John", lastName = "Giumanca" },
                new User { firstName ="Alex", lastName = "Cojocaru" },                
            };
        }
    }
}