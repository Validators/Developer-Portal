using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Validators.IO.Developers.Database;
using Validators.IO.Developers.Models;

[assembly: HostingStartup(typeof(Validators.IO.Developers.Areas.Identity.IdentityHostingStartup))]
namespace Validators.IO.Developers.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("AppDbContextConnection")));

				// Defined in startup.cs
				//
                //services.AddDefaultIdentity<IdentityUser>()
                //    .AddEntityFrameworkStores<AppDbContext>();
            });
        }
    }
}