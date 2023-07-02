using System.ComponentModel.DataAnnotations;

namespace ApplicationForTest.Models
{
    public class Answer
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public Guid? QuestionId { get; set; }
        public bool isRight { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateTimeStamp { get; set; }
    }
}