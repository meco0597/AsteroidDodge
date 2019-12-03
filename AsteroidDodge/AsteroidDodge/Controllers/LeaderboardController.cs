using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsteroidDodge.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AsteroidDodge.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly AsteroidDodgeContext _context;
        private readonly UserManager<AsteroidUser> _userManager;

        public LeaderboardController(AsteroidDodgeContext context, UserManager<AsteroidUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        /// <summary>
        /// Helper method to get current user with ship and background data fetched
        /// </summary>
        /// <returns></returns>
        public AsteroidUser GetCurrentUser()
        {
            // Fetch user with included ship/background meta data
            return _userManager.Users
                    .FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
        }


        /// <summary>
        /// POST: /Store/AddUserScore
        /// 
        /// Helper method to add a new user score 
        /// </summary>
        /// <param name="score"></param>
        [HttpPost]
        public IActionResult AddUserScore(int score)
        {
            bool result = false;
            AsteroidUser user = GetCurrentUser();

            // TODO: check if user actually finished a game?
            if(user != null)
            {
                Leaderboard leadboardEntry = new Leaderboard { AsteroidUserId = user.Id, Score = score };
                _context.Leaderboard.Add(leadboardEntry);
                _context.SaveChanges();

                result = true;
            }

            return new JsonResult(new { success = result});
        }

        // GET: /Leaderboard/
        public IActionResult Index()
        {
            // Generate ordered leaderboard
            List<Leaderboard> lb = _context.Leaderboard
                                    .Include(lb => lb.AsteroidUser)
                                    .OrderByDescending(l => l.Score)
                                    .Take(100) // limit to 100
                                    .ToList();
            return View(lb);
        }
    }
}
