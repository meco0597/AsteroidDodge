using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsteroidDodge.Models;
using AsteroidDodge.Models.Store;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static AsteroidDodge.Models.Store.StoreModel;

namespace AsteroidDodge.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private readonly AsteroidDodgeContext _context;
        private readonly UserManager<AsteroidUser> _userManager;

        public StoreController(AsteroidDodgeContext context, UserManager<AsteroidUser> userManager)
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

        public int GetCurrentCoins()
        {
            return GetCurrentUser().Coins;
        }


        // ==================================================================================
        // POST METHODS 
        // ==================================================================================
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


        /// <summary>
        /// POST: /Store/AdjustCoins
        /// 
        /// Helper method to adjust a user's coins 
        /// </summary>
        /// <param name="deltaCoins"></param>
        [HttpPost]
        public IActionResult AdjustCoins(int deltaCoins)
        {
            bool result = false;
            AsteroidUser user = GetCurrentUser();
            if(user != null)
            {
                user.Coins += deltaCoins;
                if (user.Coins < 0)
                    user.Coins = 0;

                _context.Users.Update(user);
                _context.SaveChanges();

                result = true;
            }

            return new JsonResult(new { success = result});
        }

        /// <summary>
        /// POST: /Store/PurchaseShip
        /// </summary>
        /// <param name="shipSkinName"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PurchaseShip(string shipSkinName)
        {
            bool result = false;

            ShipSkin shipSkin = _context.ShipSkins.FirstOrDefault(s => s.SkinName == shipSkinName);
            AsteroidUser curUser = GetCurrentUser();

            if (shipSkin != null &&
                curUser != null &&
                curUser.Coins >= shipSkin.SkinCost)
            {
                // Adjust users coins and add ship to database
                AdjustCoins(shipSkin.SkinCost);

                OwnedShip purchasedShip = new OwnedShip { AsteroidUser = curUser, ShipSkinId = shipSkin.ShipSkinId };
                _context.OwnedShips.Add(purchasedShip);
                _context.Users.Update(curUser);
                _context.SaveChanges();

                // Succeeded purchasing
                result = true;
            }

            return new JsonResult(new { success = result, ship = shipSkin});
        }

        /// <summary>
        /// POST: /Store/PurchaseBackground
        /// </summary>
        /// <param name="backgroundSkinName"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PurchaseBackground(string backgroundSkinName)
        {
            bool result = false;

            BackgroundSkin backgroundSkin = _context.BackgroundSkins.FirstOrDefault(s => s.SkinName == backgroundSkinName);
            AsteroidUser curUser = GetCurrentUser();

            if (backgroundSkin != null &&
                curUser != null &&
                curUser.Coins >= backgroundSkin.SkinCost)
            {
                // Adjust users coins and add ship to database
                AdjustCoins(backgroundSkin.SkinCost);

                OwnedBackground purchasedBackground = new OwnedBackground { AsteroidUser = curUser, BackgroundSkinId = backgroundSkin.BackgroundSkinId };
                _context.OwnedBackgrounds.Add(purchasedBackground);
                _context.Users.Update(curUser);
                _context.SaveChanges();

                // Succeeded purchasing
                result = true;
            }

            return new JsonResult(new { success = result, background = backgroundSkin });
        }

        /// <summary>
        /// POST: /Store/SetCurrentShip
        /// 
        /// Sets the ship of the current user
        /// </summary>
        /// <param name="shipSkinName"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SetCurrentShip(string shipSkinName)
        {
            bool result = false;

            ShipSkin shipSkin = _context.ShipSkins.FirstOrDefault(s => s.SkinName == shipSkinName);
            AsteroidUser curUser = GetCurrentUser();

            // Check if skin and user are valid. Lastly, verify that user actually owns this skin
            if (shipSkin != null &&
                curUser != null &&
                curUser.OwnedShips.ToList().Exists(os => os.ShipSkinId == shipSkin.ShipSkinId)) 
            {
                // Update and save user's current ship
                curUser.CurrentShipId = shipSkin.ShipSkinId;
                _context.Users.Update(curUser);
                _context.SaveChanges();

                // Succeeded purchasing
                result = true;
            }

            return new JsonResult(new { success = result, ship = shipSkin });
        }

        /// <summary>
        /// POST: /Store/SetCurrentBackground
        /// 
        /// Sets the background of the current user
        /// </summary>
        /// <param name="backgroundSkinName"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SetCurrentBackground(string backgroundSkinName)
        {
            bool result = false;

            BackgroundSkin backgroundSkin = _context.BackgroundSkins.FirstOrDefault(s => s.SkinName == backgroundSkinName);
            AsteroidUser curUser = GetCurrentUser();

            // Check if skin and user are valid. Lastly, verify that user actually owns this skin
            if (backgroundSkin != null &&
                curUser != null &&
                curUser.OwnedBackgrounds.ToList().Exists(os => os.BackgroundSkinId == backgroundSkin.BackgroundSkinId)) 
            {
                // Update and save user's current background
                curUser.CurrentBackgrounId = backgroundSkin.BackgroundSkinId;
                _context.Users.Update(curUser);
                _context.SaveChanges();

                // Succeeded purchasing
                result = true;
            }

            return new JsonResult(new { success = result, background = backgroundSkin });
        }


        // GET: /Store/
        public IActionResult Index()
        {
            AsteroidUser user = GetCurrentUser();

            // Get all of the user's owned ship objects
            List<OwnedShip> ownedShips = _context.OwnedShips
                .Include(os => os.ShipSkin)
                .Where(os => os.AsteroidUserId == user.Id)
                .ToList();

            // Next loop through and add ships
            List<StoreShip> storeShips = new List<StoreShip>();
            foreach (var ship in _context.ShipSkins)
            {
                // Set ship to purchased if user has it
                bool isPurchased = ownedShips
                    .Exists(os => os.ShipSkin == ship);

                StoreShip ss = new StoreShip { ShipSkin = ship, IsPurchased = isPurchased};
                storeShips.Add(ss);
            }

            // Get all of the user's owned background skin objects
            List<OwnedBackground> ownedBkgnds = _context.OwnedBackgrounds
                .Include(ob => ob.BackgroundSkin)
                .Where(ob => ob.AsteroidUserId == user.Id)
                .ToList();

            // Loop through and add bkgrnds
            List<StoreBackground> storeBackgrounds = new List<StoreBackground>();
            foreach (var bkgrnd in _context.BackgroundSkins)
            {
                // Set background to purchased if user has it
                bool isPurchased = ownedBkgnds
                    .Exists(ob => ob.BackgroundSkin == bkgrnd);

                StoreBackground sb = new StoreBackground { BackgroundSkin = bkgrnd, IsPurchased = isPurchased};
                storeBackgrounds.Add(sb);
            }

            // Build model and return to view
            return View(new StoreModel { User = user, StoreShips = storeShips, StoreBackgrounds = storeBackgrounds } );
        }


    }
}
