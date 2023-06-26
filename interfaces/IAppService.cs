using ApplicationForTest.Models;

namespace ApplicationForTest.Interfaces
{
    public interface IAppService
    {
        Task<List<Course>> GetCourses();

        Task<Course> GetCourse(int? id);

        Task CreateCourse(Course course);

        Task UpdateCourse(Course course);

        Task RemoveCourse(int? id);

        Task<List<Test>> GetTests(int? courseId);

        Task<Test> GetTest(Guid? id);

        Task CreateTest(Test test);

        Task UpdateTest(Test test);

        Task RemoveTest(Guid? id);

        Task<List<Question>> GetQuestions(Guid testId);

        Task<Question> GetQuestion(Guid? id);

        Task CreateQuestion(Question question);

        Task UpdateQuestion(Question question);

        Task RemoveQuestion(Guid? id);

        Task<List<Answer>> GetAnswers(Guid questionId);

        Task<Answer> GetAnswer(Guid? id);

        Task CreateAnswer(Answer answer);

        Task UpdateAnswer(Answer answer);

        Task RemoveAnswer(Guid? id);
    }
}