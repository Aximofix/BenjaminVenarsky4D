using Microsoft.AspNetCore.Mvc;
using Projekt.Models;

namespace Projekt.Controllers
{
    public class UlohyController : Controller
    {
        public IActionResult Uloha1()
        {
            return View();
        }

        public IActionResult Uloha2()
        {
            return View();
        }

        public IActionResult Uloha3()
        {
            return View();
        }

        public IActionResult Uloha4()
        {
            var users = new List<UserInfo>() {
                new UserInfo() {
                    Name = "Alex",
                    LastName = "Vyšný",
                    Email = "robertopekny@gmail.com",
                    Phone = "0944 156 153",
                },
                new UserInfo() {
                    Name = "Benjamín",
                    LastName = "Veňarský",
                    Email = "bve357@gmail.com",
                    Phone = "0944 573 179",
                },
                new UserInfo() {
                    Name = "Ján",
                    LastName = "Novák",
                    Email = "jan.novak@example.com",
                    Phone = "0946 456 564",
                },
                new UserInfo() {
                    Name = "Jana",
                    LastName = "Kováčová",
                    Email = "jana.kovacova@example.com",
                    Phone = "0956 412 323",
                },
                new UserInfo() {
                    Name = "Miro",
                    LastName = "Pavlík",
                    Email = "miro.pavlik@example.com",
                    Phone = "0984 856 155",
                }
            };
            return View(users);
        }

        public IActionResult Uloha5()
        {
            var users = new List<UserInfo>() {
                new UserInfo() {
                    Name = "Alex",
                    LastName = "Vyšný",
                    Email = "robertopekny@gmail.com",
                    Phone = "0944 156 153",
                },
                new UserInfo() {
                    Name = "Benjamín",
                    LastName = "Veňarský",
                    Email = "bve357@gmail.com",
                    Phone = "0944 573 179",
                },
                new UserInfo() {
                    Name = "Ján",
                    LastName = "Novák",
                    Email = "jan.novak@example.com",
                    Phone = "0946 456 564",
                },
                new UserInfo() {
                    Name = "Jana",
                    LastName = "Kováčová",
                    Email = "jana.kovacova@example.com",
                    Phone = "0956 412 323",
                },
                new UserInfo() {
                    Name = "Miro",
                    LastName = "Pavlík",
                    Email = "miro.pavlik@example.com",
                    Phone = "0984 856 155",
                }
                ,
                new UserInfo() {
                    Name = "Urban",
                    LastName = "Tupý",
                    Email = "urban.tupy@example.com",
                    Phone = "0534 512 153",
                }
            };
            return View(users);
        }


        public IActionResult Uloha6()
        {
            return View();
        }

        public IActionResult Uloha7()
        {
            return View();
        }
    }
}
