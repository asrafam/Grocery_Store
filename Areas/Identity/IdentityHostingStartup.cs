using System;
using Grocery_Store.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Grocery_Store.Areas.Identity.IdentityHostingStartup))]
namespace Grocery_Store.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<Grocery_StoreContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Grocery_StoreContextConnection")));

                //services.AddDefaultIdentity<IdentityUser,IdentityRole>()
                //    .AddEntityFrameworkStores<Grocery_StoreContext>();

                services.AddIdentity<IdentityUser, IdentityRole>()
      .AddEntityFrameworkStores<Grocery_StoreContext>()
      .AddDefaultTokenProviders();

            });
        }
    }
}