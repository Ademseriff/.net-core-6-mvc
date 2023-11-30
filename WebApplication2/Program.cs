using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static WebApplication2.Entities.User;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //database i�lemleri i�in servis tan�mlamas� ve connection stringi yazd�k cs json dosyas� i�inde.
            builder.Services.AddDbContext<DataBaseContext>(opts =>
            {
                opts.UseSqlServer("server=localhost;database=WebApplication2DB;Trusted_Connection=True;MultipleActiveResultSets=true");
                
            });
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opts =>
            {
                opts.Cookie.Name = "webapplication.auth";
                opts.ExpireTimeSpan = TimeSpan.FromDays(1);
                opts.LoginPath = "/Account/Login";
                opts.LogoutPath = "/Account/Logout";
            });
            //"server=localhost;database=WebApp;Trusted_Connection=True;MultipleActiveResultSets=true"
            
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