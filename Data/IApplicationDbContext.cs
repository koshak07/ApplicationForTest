using ApplicationForTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationForTest.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Course> Courses { get; set; }
        DbSet<Test> Tests { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Answer> Answers { get; set; }
    }
}