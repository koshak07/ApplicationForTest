using ApplicationForTest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApplicationForTest.Data
{
    

    public class UserDBContext : IdentityDbContext<ApplicationUser>
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}