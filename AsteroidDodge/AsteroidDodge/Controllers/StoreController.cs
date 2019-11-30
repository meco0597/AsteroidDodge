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
    public class StoreController : Controller
    {
        private readonly AsteroidDodgeContext _context;
        private readonly UserManager<AsteroidUser> _userManager;

        public StoreController(AsteroidDodgeContext context, UserManager<AsteroidUser> userManager)
        {
            _context = context;
            _userManager = userManager;

            // Pre-fetch owned ships and backgrounds 
            //_userManager.Users
                //.Include(u => u.OwnedShips.Select(os => os.ShipSkin));
                //.Include(u => u.OwnedBackgrounds.Select(bg => bg.BackgroundSkin));
        }

        /// <summary>
        /// Helper method to get current user
        /// </summary>
        /// <returns></returns>
        private Task<AsteroidUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        /// <summary>
        /// Helper method to adjust a user's coins 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="deltaCoins"></param>
        public void AdjustCoins(AsteroidUser user, int deltaCoins)
        {
            user.Coins += deltaCoins;
            if (user.Coins < 0)
                user.Coins = 0;

            _context.Users.Update(user);
            _context.SaveChanges();
        }


        // GET: /Store/
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// POST: /Store/PurchaseShip
        /// </summary>
        /// <param name="shipSkinName"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PurchaseShip(string shipSkinName)
        {
            bool result = false;

            ShipSkin shipSkin = _context.ShipSkins.FirstOrDefault(s => s.SkinName == shipSkinName);
            AsteroidUser curUser = await GetCurrentUserAsync();

            if (shipSkin != null &&
                curUser != null &&
                //curUser.OwnedShips.ToList().Exists(os => os.ShipSkin == shipSkin) &&
                curUser.Coins >= shipSkin.SkinCost)
            {
                // Adjust users coins and add ship to database
                AdjustCoins(curUser, shipSkin.SkinCost);

                OwnedShip purchasedShip = new OwnedShip { AsteroidUser = curUser, ShipSkinId = shipSkin.ShipSkinId};
                //curUser.OwnedShips.Add(purchasedShip);
                _context.Users.Update(curUser);
                _context.SaveChanges();

                // Succeeded purchasing
                result = true;
            }

            return new JsonResult(new { success = result});
        }
    }
}
