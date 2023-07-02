using ApplicationForTest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApplicationForTest.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<Test> Tests { get; set; } = default!;
        public DbSet<Question> Questions { get; set; } = default!;
        public DbSet<Answer> Answers { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            string ADMIN_ID = "a11fa953-09da-4c57-88e6-9bfaf3c46a80";
            string USER_ID = "17423714-fb1c-482c-8677-a914ace43b40";
            string ROLE_ID = "3a916b4c-66ec-432d-924f-b3377aba9064";
            string USER_ROLE_ID = "17423714-fb1c-482c-8677-a914ace43b40";

            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            });

            //create user
            var appAdmin = new ApplicationUser
            {
                Id = ADMIN_ID,
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                UserName = "Admin",
                NormalizedUserName = "ADMIN@GMAIL.COM"
            };
            var appUser = new ApplicationUser
            {
                Id = USER_ID,
                Email = "user@gmail.com",
                EmailConfirmed = true,
                UserName = "User",
                NormalizedUserName = "USER@GMAIL.COM"
            };

            //set user password
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            {
                appAdmin.PasswordHash = ph.HashPassword(appAdmin, "mypassword_ ?");
                appUser.PasswordHash = ph.HashPassword(appUser, "mypassword1_ ?");
            }

            //seed user
            builder.Entity<ApplicationUser>().HasData(appAdmin);
            builder.Entity<ApplicationUser>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = USER_ROLE_ID,
                UserId = USER_ID
            });

            base.OnModelCreating(builder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

        //    modelBuilder.AddApplicationUserSeedData();
        //}
    }
}