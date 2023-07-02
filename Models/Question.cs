using System.ComponentModel.DataAnnotations;

namespace ApplicationForTest.Models
{
    public class Question
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public Guid? TestId { get; set; }

        public ICollection<Answer>? Answers { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateTimeStamp { get; set; }
    }
}