using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projekt.Models;
using UserApp.DataLayer;
using UserApp.DataLayer.Entities;

namespace Projekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Users()
        {
            var userList = _context.Users.ToList();

            //var userList = new List<UserEntity>()
            //{
            //    new UserEntity()
            //    {
            //        Id = 1, Name = "A", Email = "a", PublicId = Guid.NewGuid()
            //    },
            //    new UserEntity()
            //    {
            //        Id = 2, Name = "User", Email = "email@email.sk", PublicId = Guid.NewGuid()
            //    }
            //};

            return View(userList);
        }

        [HttpPost]
        public IActionResult Users(Guid Id)
        {
            var user = _context.Users.FirstOrDefault(u => u.PublicId == Id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            var userList = _context.Users.ToList();
            return View(userList);
        }

        public IActionResult UserDetail(Guid userPublicId)
        {
            var user = _context.Users.FirstOrDefault(u => u.PublicId == userPublicId);
            return View(user);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserModel user)
        {
            ViewBag.error = "";

            if (user == null)
            {
                ViewBag.error = "Wrong input!";
            }
            else
            {
                if (user.UserName == null || user.UserName == "")
                {
                    ViewBag.error = "Wrong input!";
                }
                else
                {
                    if (user.Password == null || user.Password == "")
                    {
                        ViewBag.error = "Wrong input!";
                    }
                    else
                    {
                        if (user.Email == null || user.Email == "")
                        {
                            ViewBag.error = "Wrong input!";
                        }
                        else
                        {
                            var user1 = new UserEntity() { Id = _context.Users.ToList().Count+1, Name = user.UserName, Email = user.Email, PublicId = Guid.NewGuid() };
                            _context.Users.Add(user1);
                            _context.SaveChanges();
                            ViewBag.error = "idk";
                            return RedirectToAction("Users");   
                        }
                    }
                }
            }

            return View();
        }

        public IActionResult Update(Guid Id)
        {
            var user = _context.Users.FirstOrDefault(u => u.PublicId == Id);
            var model = new UpdateModel(){ Id = Id, UserName = user.Name };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UpdateModel user)
        {
            if (user.Email == null || user.Email == "")
            {
                ViewBag.Error = "Blank input!";
                var model = new UpdateModel() { Id = user.Id, UserName = user.UserName };
                return View(model);
            }
            else
            {
                var u = _context.Users.FirstOrDefault(u => u.PublicId == user.Id);
                u.Email = user.Email;
                _context.Update(u);
                _context.SaveChanges();
                return RedirectToAction("Users");
            }
        }



    }
}
