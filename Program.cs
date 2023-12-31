using ApplicationForTest.Data;
using ApplicationForTest.Interfaces;
using ApplicationForTest.Models;
using ApplicationForTest.Servises;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApplicationForTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var userconnectionString = builder.Configuration.GetConnectionString("UserConnection");

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            //builder.Services.AddDbContext<UserDBContext>(options =>
            //    options.UseSqlServer(userconnectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            // Add services to the container.
            builder.Services.AddTransient<IAppService, AppService>();
            builder.Services.AddTransient<IApplicationDbContext, ApplicationDbContext>();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()

                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //using (var scope = app.Services.CreateScope())
            //{
            //    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            //    var roles = new[] { "Admin", "Student" };

            //    foreach (var role in roles)
            //    {
            //        if (!await roleManager.RoleExistsAsync(role))
            //            await roleManager.CreateAsync(new ApplicationRole(role));
            //    }
            //}

            app.MapRazorPages();

            app.Run();
        }
    }
}