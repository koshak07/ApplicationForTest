using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ApplicationForTest.Models
{
    public class Test
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? CourseId { get; set; }

        public ICollection<Question>? Questions { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateTimeStamp { get; set; }
    }
}