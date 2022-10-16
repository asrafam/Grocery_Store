using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grocery_Store.Context;
using Grocery_Store.Models;
using Grocery_Store.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Grocery_Store
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            
            services.AddAuthorization(options => {
                options.AddPolicy("readonlypolicy",
                    builder => builder.RequireRole("Admin", "Manager", "User"));
                options.AddPolicy("writepolicy",
                    builder => builder.RequireRole("Admin", "Manager"));
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = new PathString("/Identity/Account/Login");
                options.SlidingExpiration = true;
            });
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.AccessDeniedPath = new PathString("/Identity/Account/AccessDenied");
                options.SlidingExpiration = true;
            });
            services.AddDbContext<ProductDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
      //      services.AddIdentity<IdentityUser, IdentityRole>()
      //           .AddEntityFrameworkStores<ProductDbContext>();
      //      services.AddIdentity<IdentityUser, IdentityRole>()
      //.AddEntityFrameworkStores<ProductDbContext>()
      //.AddDefaultTokenProviders();


      //      services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
      //       .AddEntityFrameworkStores<ProductDbContext>();


            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddMvc();
           
            //services.AddDbContext<InputProductContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env/*, ILoggerManager logger*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            app.UseExceptionMiddleware();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("MyKey");
            //});
            //app.ConfigureExceptionHandler(logger);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();
            //app.ConfigureCustomExceptionMiddleware();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        public class EmailSender : IEmailSender
        {
            public Task SendEmailAsync(string email, string subject, string message)
            {
                return Task.CompletedTask;
            }
        }
    }
}
