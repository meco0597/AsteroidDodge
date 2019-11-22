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
            // This is just random test data to test the view have to replace this with database
            Dictionary<string, int> testData = new Dictionary<string, int>();
            int seed = 300;
            testData.Add("Melvin", seed);
            testData.Add("Chris", seed - 10);
            testData.Add("Carl", seed - 15);
            testData.Add("Judy", seed - 20);
            testData.Add("Spencer", seed - 25);
            testData.Add("Sarah", seed - 30);
            testData.Add("Sean", seed - 35);
            testData.Add("Jake", seed - 40);
            testData.Add("Kent", seed - 45);
            testData.Add("Randy", seed - 50);

            return View(testData);
        }
    }
}
