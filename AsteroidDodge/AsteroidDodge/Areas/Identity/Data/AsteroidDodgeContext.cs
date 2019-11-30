using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AsteroidDodge.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

            //builder.Entity<OwnedShip>(entity =>
            //{
            //    entity.HasKey(os => new { os.AsteroidUserId, os.ShipSkinId });
            //    entity.HasOne("AsteroidUser");
            //    entity.HasOne("ShipSkin");
            //});

            //builder.Entity<ShipSkin>(entity =>
            //{
            //    entity.HasOne("ShipSkin");
            //});

            //builder.Entity<AsteroidUser>(entity =>
            //{
            //    entity.HasMany("OwnedShip");
            //});

            //builder.Entity<OwnedShip>()
            //    .HasKey(os => new { os.OwnedShipId });


            //builder.Entity<OwnedBackground>()
            //    .HasKey(ob => new { ob.OwnedBackgroundId });

       }
    }
}
