using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsteroidDodge.Models;
using Microsoft.AspNetCore.Identity;

namespace AsteroidDodge.Data
{
    public static class DBInitializer
    {
        private static string password = "Password_123";
        /// <summary>
        /// Public database initialization method
        /// </summary>
        /// <param name="context"></param>
        public static async Task Initialize(AsteroidDodgeContext context, UserManager<IdentityUser> userManager)
        {
            // Check to make sure db is properly created
            context.Database.EnsureCreated();

            await CreatePlayers(userManager);
        }

        private static async Task CreatePlayers(UserManager<IdentityUser> userManager)
        {
            var players = new IdentityUser[]
            {
                new IdentityUser()
                    {UserName = "Player1@utah.edu", Email = "Player1@utah.edu", EmailConfirmed = true},
                new IdentityUser()
                    {UserName = "Player2@utah.edu", Email = "Player2@utah.edu", EmailConfirmed = true},
                new IdentityUser()
                    {UserName = "Player3@utah.edu", Email = "Player3@utah.edu", EmailConfirmed = true}
            };gfh

            foreach (var player in players)
            {
                await userManager.CreateAsync(player, password);
            }
        }
    }
}
