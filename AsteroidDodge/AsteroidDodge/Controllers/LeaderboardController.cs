using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsteroidDodge.Controllers
{
    public class LeaderboardController : Controller
    {
        // GET: /Leaderboard/
        public IActionResult Index()
        {
            return View();
        }
    }
}
