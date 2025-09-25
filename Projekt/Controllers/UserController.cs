using Microsoft.AspNetCore.Mvc;
using Projekt.Models;

namespace Projekt.Controllers
{
    public class UserController : Controller
    {
        private static List<UserInfo> userList { get; set; } = new List<UserInfo>();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserForm()
        {
            return View(new UserInfo());
        }

        [HttpPost]
        public IActionResult UserForm(UserInfo user)
        {
            user.Predmety = [];
            string[] predmety = user.Helpfull.Split(',');
            foreach(var predmet in predmety)
            {
                user.Predmety.Add(predmet);
            }
            userList.Add(user);
            return RedirectToAction("Detail", user);
        }


        public IActionResult Detail(UserInfo user)
        {
            ViewBag.users = userList;
            return View(user);
        }
    }
}
