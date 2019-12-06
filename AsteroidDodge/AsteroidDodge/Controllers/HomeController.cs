using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AsteroidDodge.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AsteroidDodge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AsteroidDodgeContext _context;
        private readonly UserManager<AsteroidUser> _userManager;

        public HomeController(ILogger<HomeController> logger, AsteroidDodgeContext context, UserManager<AsteroidUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Helper method to get current user with ship and background data fetched
        /// </summary>
        /// <returns></returns>
        public string GetCurrentBackground()
        {
            // Fetch user with included ship/background meta data
            AsteroidUser curUser = _userManager.Users
                .FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);


            if (curUser != null)
            {
                return "../images/b" + (curUser.CurrentBackgrounId + 1) + ".jpg";
            }
            else
            {
                return "../images/b1.jpg";
            }
        }

        public IActionResult Index()
        {
            return View("Index", GetCurrentBackground());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Helper method to get current user with ship and background data fetched
        /// </summary>
        /// <returns></returns>
        public AsteroidUser GetCurrentUser()
        {
            // Fetch user with included ship/background meta data
            return _userManager.Users
                .Include(u => u.OwnedShips)
                .Include(u => u.OwnedBackgrounds)
                .FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
        }

        /// <summary>
        /// Helper method to call in the JavaScript
        /// </summary>
        /// <returns>Path to the current ship</returns>
        public IActionResult GetUserShip()
        {
            AsteroidUser user = GetCurrentUser();

            if (user != null)
            {
                if (user.CurrentShipId != 0)
                    return new JsonResult(new {success = true, imageSrc = "../images/s" + (user.CurrentShipId + 1) + ".png"});
                else
                    return new JsonResult(new { success = true, imageSrc = "../images/s1.png" });
            }
            else
            {
                return new JsonResult(new { success = true, imageSrc = "../images/s1.png" });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
