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
                opts.UseSqlServer("Server:localhost;Database:WebApplication2DB;Trusted_Connecttion=true");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}