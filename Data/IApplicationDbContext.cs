using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationForTest.Models;

namespace ApplicationForTest.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Course> Course { get; set; }
        DbSet<Test> Test { get; set; }
        DbSet<Question> Question { get; set; }
        DbSet<Answer> Answer { get; set; }
    }
}