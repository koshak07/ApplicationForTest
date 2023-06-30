using ApplicationForTest.Entities;
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
            string ROLE_ID = "3a916b4c-66ec-432d-924f-b3377aba9064";

            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            //create user
            var appUser = new ApplicationUser
            {
                Id = ADMIN_ID,
                Email = "frankofoedu@gmail.com",
                EmailConfirmed = true,
                UserName = "Frank",
                NormalizedUserName = "FRANKOFOEDU@GMAIL.COM"
            };


            //set user password
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "mypassword_ ?");

            //seed user
            builder.Entity<ApplicationUser>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
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