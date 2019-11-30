using System;
using AsteroidDodge.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AsteroidDodge.Areas.Identity.IdentityHostingStartup))]
namespace AsteroidDodge.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AsteroidDodgeContext>(options =>
                    options.UseSqlite("Data Source=./Database/AsteroidDodgeDatabase.db"));

                services.AddDefaultIdentity<AsteroidUser>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<AsteroidDodgeContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            });

        }
    }
}