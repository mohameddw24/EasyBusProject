using EasyBus.Models;
using EasyBusProject.Models;
using EasyBusProject.RepoServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System;

namespace EasyBusProject
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

         

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var connectionString = builder.Configuration.GetConnectionString("EasyBusConn") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<MainDbContext>(options =>
               options.UseSqlServer(connectionString));

            builder.Services.AddScoped<StationRepoServices>();
            builder.Services.AddScoped<UserScheduleRepoServices>();
            builder.Services.AddScoped<ContactUsRepoService>();
            builder.Services.AddScoped<TicketRepoService>();

            builder.Services.AddScoped<IRepository<Station>, StationRepoServices>();
            builder.Services.AddScoped<IRepository<Trip>, TripsRepoServices>();
            builder.Services.AddScoped<IRepository<Schedule>, ScheduleRepoServices>();
            builder.Services.AddScoped<IRepository<UserSchedule>, UserScheduleRepoServices>();
            builder.Services.AddScoped<IRepository<ContactUs>, ContactUsRepoService>();

            builder.Services.AddIdentity<User, IdentityRole<int>>(options => {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<MainDbContext>();



            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie()
             .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
             {
                 options.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
                 options.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;
             });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
