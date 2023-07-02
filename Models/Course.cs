using System.ComponentModel.DataAnnotations;

namespace ApplicationForTest.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public ICollection<Test>? Tests { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateTimeStamp { get; set; }
    }
}