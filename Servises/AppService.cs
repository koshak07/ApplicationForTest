using ApplicationForTest.Data;
using ApplicationForTest.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApplicationForTest.Models;

namespace ApplicationForTest.Servises
{
    public class AppService : IAppService
    {
        private ApplicationDbContext _context;

        public AppService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Creating entitys
        public async Task CreateCourse(Course course)
        {
            _context.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task CreateTest(Test test)
        {
            _context.Add(test);
            await _context.SaveChangesAsync();
        }

        public async Task CreateQuestion(Question question)
        {
            _context.Add(question);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAnswer(Answer answer)
        {
            _context.Add(answer);
            await _context.SaveChangesAsync();
        }

        //Getting entitys

        public async Task<List<Course>> GetCourses()
        {
            return await _context.Course.Include(c => c.Tests).ToListAsync();
        }

        public async Task<Course> GetCourse(int? id)
        {
            var course = await _context.Course
              .FindAsync(id);
            if (course == null)
            {
                return null;
            }

            return course;
        }

        public async Task<List<Test>> GetTests(int? courseId)
        {
            return await _context.Test.Where(p => p.CourseId == courseId).ToListAsync();
        }

        public async Task<Test> GetTest(Guid? id)
        {
            var test = await _context.Test
               .FindAsync(id);
            if (test == null)
            {
                return null;
            }

            return test;
        }

        public async Task<List<Question>> GetQuestions(Guid testId)
        {
            return await _context.Question.Where(p => p.TestId == testId).ToListAsync();
        }

        public async Task<Question> GetQuestion(Guid? id)
        {
            var question = await _context.Question
               .FindAsync(id);
            if (question == null)
            {
                return null;
            }

            return question;
        }

        public async Task<List<Answer>> GetAnswers(Guid questionId)
        {
            return await _context.Answer.Where(p => p.QuestionId == questionId).ToListAsync();
        }

        public async Task<Answer> GetAnswer(Guid? id)
        {
            var answer = await _context.Answer
               .FindAsync(id);
            if (answer == null)
            {
                return null;
            }

            return answer;
        }

        public async Task UpdateCourse(Course course)
        {
            try
            {
                _context.Update(course);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(course.Id))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool CourseExists(int id)
        {
            return (_context.Course?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task UpdateTest(Test test)
        {
            try
            {
                _context.Update(test);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(test.Id))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool TestExists(Guid id)
        {
            return (_context.Test?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task UpdateQuestion(Question question)
        {
            try
            {
                _context.Update(question);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(question.Id))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool QuestionExists(Guid id)
        {
            return (_context.Question?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task UpdateAnswer(Answer answer)
        {
            try
            {
                _context.Update(answer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerExists(answer.Id))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool AnswerExists(Guid id)
        {
            return (_context.Answer?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task RemoveCourse(int? id)
        {
            var course = await _context.Course.FindAsync(id);
            if (course != null)
            {
                _context.Course.Remove(course);
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveTest(Guid? id)
        {
            var test = await _context.Test.FindAsync(id);
            if (test != null)
            {
                _context.Test.Remove(test);
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveQuestion(Guid? id)
        {
            var question = await _context.Question.FindAsync(id);
            if (question != null)
            {
                _context.Question.Remove(question);
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAnswer(Guid? id)
        {
            var answer = await _context.Answer.FindAsync(id);
            if (answer != null)
            {
                _context.Answer.Remove(answer);
            }

            await _context.SaveChangesAsync();
        }
    }
}