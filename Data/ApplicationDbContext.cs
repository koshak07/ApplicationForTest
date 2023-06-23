using ApplicationForTest.Models;
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

        public DbSet<Course> Course { get; set; } = default!;
        public DbSet<Test> Test { get; set; } = default!;
        public DbSet<Question> Question { get; set; } = default!;
        public DbSet<Answer> Answer { get; set; } = default!;
    }
}