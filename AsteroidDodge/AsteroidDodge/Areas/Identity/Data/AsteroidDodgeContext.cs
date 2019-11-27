using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsteroidDodge.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AsteroidDodge.Models
{
    public class AsteroidDodgeContext : IdentityDbContext<AsteroidUser>
    {
        public AsteroidDodgeContext(DbContextOptions<AsteroidDodgeContext> options)
            : base(options)
        {
        }

        public DbSet<ShipSkin> ShipSkins { get; set; }
        public DbSet<BackgroundSkin> BackgroundSkins { get; set; }


        public DbSet<OwnedShip> OwnedShips { get; set; }
        public DbSet<OwnedBackground> OwnedBackgrounds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
