using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Linq;
using BusinessLayer.Interfaces.Service;
using Common.DTO;
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
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, IUserService userService)
        {
            _logger = logger;
            _context = context;
            _userService = userService;

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

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var userList = await _userService.GetAllAsync();
            var model = new UserViewModel() { userList = userList };

            var UList = await _userService.GetAllPublicIdAsync();

            ViewBag.UList = "[";
            foreach (var u in UList)
            {
                ViewBag.UList += $"'{u}'" + ",";
            }
            var a = "";

            a = ViewBag.UList;

            var i = a.Length;

            ViewBag.UList = a.Substring(0, i - 1);
            ViewBag.UList += "]";



            //var model = new UserViewModel();

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

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Users(Guid Id)
        {
            await _userService.DeleteAsync(Id);
            var userList = await _userService.GetAllAsync();
            var model = new UserViewModel() { userList = userList };

            var UList = await _userService.GetAllPublicIdAsync();

            ViewBag.UList = "[";
            foreach (var u in UList)
            {
                ViewBag.UList += $"'{u}'" + ",";
            }
            var a = "";

            a = ViewBag.UList;

            var i = a.Length;

            ViewBag.UList = a.Substring(0, i - 1);
            ViewBag.UList += "]";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Deletion(List<string> list)
        {
            var userList = await _userService.GetAllAsync();
            ViewBag.userList = userList.ToList();

            Console.WriteLine("-----------------------------------------HELP----------------------------------------");

            foreach (var user in list)
            {
                var a = user.Split(",");
                foreach (var i in a)
                {
                    //Console.WriteLine(i);
                    await _userService.DeleteAsync(new Guid(i));
                }
            }
            return RedirectToAction("Users");
        }

        public async Task<IActionResult> UserDetail(Guid userPublicId)
        {
            var user = await _userService.GetByPublicIdAsync(userPublicId);
            return View(user);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserModel user)
        {
            ViewBag.error = "";
            var u = new UserDTO() { Id = -1, Email = user.Email, Name = user.UserName, PublicId = Guid.NewGuid() };
            var adduser = await _userService.CreateAsync(u);
            if (adduser)
            {
                return RedirectToAction("Users");
            }
            else {
                ViewBag.error = "Wrong input!";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserModel user)
        {
            ViewBag.error = "";
            var u = new UserDTO() { Id = -1, Email = user.Email, Name = user.UserName, PublicId = Guid.NewGuid(), Password = user.Password };
            var adduser = await _userService.CreateAsync(u);
            if (adduser)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "Wrong input!";
            }
            return View();
        }

        public async Task<IActionResult> Update(Guid Id)
        {
            var user = await _userService.GetByPublicIdAsync(Id);
            var model = new UpdateModel(){ Id = Id, UserName = user.Name };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateModel user)
        {
            var u = new UserDTO() { PublicId = user.Id, Email = user.Email, Name = user.UserName };
            var updateuser = await _userService.UpdateAsync(u);

            if (!updateuser)
            {
                ViewBag.Error = "Blank input!";
                var model = new UpdateModel() { Id = user.Id, UserName = user.UserName };
                return View(model);
            }
            else
            {
                return RedirectToAction("Users");
            }
        }


    }
}
