using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityLad.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityLad
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MembersDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContext<MyIdentityContext>(o => o.UseSqlServer(connString));

            services.AddIdentity<MyidentityUser, IdentityRole>(o=>
            {
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            }
            )
                .AddEntityFrameworkStores<MyIdentityContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(
                 o => o.LoginPath = "/Members/LogIn");

            services.AddAuthentication(
              CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(o => o.LoginPath = "/Members/Login");
            services.AddMvc();
            services.AddTransient<MembersService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseAuthentication();
                app.UseDeveloperExceptionPage();
                app.UseMvcWithDefaultRoute();
            }
        }
    }
}
