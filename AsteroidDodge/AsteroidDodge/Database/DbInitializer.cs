using AsteroidDodge.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsteroidDodge.Database
{
    public class DbInitializer
    {
        /// <summary>
        /// Default ship acessor
        /// </summary
        public static readonly ShipSkin DEFAULT_SHIP = new ShipSkin { ShipSkinId = 1, SkinCost = 0, SkinName = "Default Ship", SkinImgLocation = "./images/s1.png" };

        private static AsteroidUser[] USERS =
        {
            new AsteroidUser{ UserName = "professor_jim@cs.utah.edu", Email = "professor_jim@cs.utah.edu"},
            new AsteroidUser{ UserName = "professor_mary@cs.utah.edu", Email = "professor_mary@cs.utah.edu"},
            new AsteroidUser{ UserName = "professor_danny@cs.utah.edu", Email = "professor_danny@cs.utah.edu"}
        };

        private static ShipSkin[] SKINS =
        {
            new ShipSkin {ShipSkinId = 2, SkinCost = 100, SkinName = "Purple Fury", SkinImgLocation = "/images/s2.png"},
            new ShipSkin {ShipSkinId = 3, SkinCost = 250, SkinName = "Dark Thunder", SkinImgLocation = "/images/s3.png"},
            new ShipSkin {ShipSkinId = 4, SkinCost = 500, SkinName = "Yellow Falcon", SkinImgLocation = "/images/s4.png"},
            new ShipSkin {ShipSkinId = 5, SkinCost = 800, SkinName = "Red Tiger", SkinImgLocation = "/images/s5.png"},
            new ShipSkin {ShipSkinId = 6, SkinCost = 1200, SkinName = "Sapphire Shark", SkinImgLocation = "/images/s6.png"},
            new ShipSkin {ShipSkinId = 7, SkinCost = 2000, SkinName = "Millennium Falcon", SkinImgLocation = "/images/s7.png"}
        };

        private static BackgroundSkin[] BCKGRDSKIN =
        {
            new BackgroundSkin {BackgroundSkinId = 0, SkinName = "Default", SkinCost = 0, SkinImgLocation = "/images/b1.jpg"},
            new BackgroundSkin {BackgroundSkinId = 1, SkinName = "Galactic Edros", SkinCost = 10, SkinImgLocation = "/images/b2.jpg"},
            new BackgroundSkin {BackgroundSkinId = 2, SkinName = "Natalist Kapta", SkinCost = 25, SkinImgLocation = "/images/b3.jpg"},
            new BackgroundSkin {BackgroundSkinId = 3, SkinName = "Nebula", SkinCost = 50, SkinImgLocation = "/images/b4.jpg"},
            new BackgroundSkin {BackgroundSkinId = 4, SkinName = "Earth", SkinCost = 100, SkinImgLocation = "/images/b5.jpg"}
        };


        internal static Task Initialize(AsteroidDodgeContext context, UserManager<AsteroidDodgeContext> userManager)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Public database initialization method
        /// </summary>
        /// <param name="context"></param>
        public static async Task Initialize(AsteroidDodgeContext context, UserManager<AsteroidUser> userManager)
        {
            // Check to make sure db is properly created
            context.Database.EnsureCreated();

            if (!context.ShipSkins.Contains(DEFAULT_SHIP))
                context.ShipSkins.Add(DEFAULT_SHIP);

            // Loop through and add all skins
            foreach(ShipSkin skin in SKINS)
            {
                if(!context.ShipSkins.Contains(skin))
                {
                    context.ShipSkins.Add(skin);
                }
            }

            context.SaveChanges();


            string pass = "Cs4540!";

            // Loop through and create all new users
            foreach (AsteroidUser user in USERS)
            {
                var findRes = await userManager.FindByEmailAsync(user.Email);
                if(findRes == null)
                {
                    await userManager.CreateAsync(user, pass);
                    OwnedShip owned = new OwnedShip { AsteroidUserId = user.Id, ShipSkinId = DEFAULT_SHIP.ShipSkinId };
                    context.OwnedShips.Add(owned);
                }
            }

            foreach (var backgroundSkin in BCKGRDSKIN)
            {
                if (!context.BackgroundSkins.Contains(backgroundSkin))
                    context.BackgroundSkins.Add(backgroundSkin);
            }

            context.SaveChanges();
        }
    }
}
