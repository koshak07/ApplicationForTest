using ApplicationForTest.Interfaces;
using ApplicationForTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationForTest.Controllers
{
    [Authorize(Roles = "SuperAdmin,User")]
    public class AppController : Controller
    {
        private readonly IAppService appService;

        public AppController(IAppService appService)
        {
            this.appService = appService;
        }

        // GET: Courses List
        public async Task<IActionResult> Index()
        {
            var result = await appService.GetCourses();

            return View(result);
        }

        // GET: Course/Details/
        public async Task<IActionResult> Details(int? id)
        {
            var course = await appService.GetCourse(id);
            ViewData["Course"] = course;
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Tests List

        public async Task<IActionResult> IndexTests(int id)
        {
            var result = await appService.GetTests(id);
            ViewData["id"] = id;
            ViewData["count"] = result.Count;

            return View(result);
        }

        // GET: Test/Details/
        public async Task<IActionResult> DetailsTest(Guid? id)
        {
            var test = await appService.GetTest(id);

            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        // GET: Questions List
        public async Task<IActionResult> IndexQuestions(Guid id)
        {
            var result = await appService.GetQuestions(id);
            ViewData["id"] = id;
            ViewData["count"] = result.Count;

            List<Answer> answList = new List<Answer>();

            foreach (var q in result)
            {
                var list = await appService.GetAnswers(q.Id);
                answList.AddRange(list);
            }

            ViewBag.Answer = answList;

            return View(result);
        }

        // GET: Question/Details/
        public async Task<IActionResult> DetailsQuestion(Guid? id)
        {
            var result = await appService.GetQuestion(id);
            var answList = await appService.GetAnswers(id);
            ViewBag.Answ = new List<Answer>(answList);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // GET: Answers List

        public async Task<IActionResult> IndexAnswers(Guid id)
        {
            var result = await appService.GetAnswers(id);
            ViewData["id"] = id;
            ViewData["count"] = result.Count;

            return View(result);
        }

        // GET: Answer/Details/

        public async Task<IActionResult> DetailsAnswer(Guid? id)
        {
            var result = await appService.GetAnswer(id);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // GET: Course/Create

        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
                                            [Bind("Id,Name,Tests")] Course course)
        {
            if (ModelState.IsValid)
            {
                await appService.CreateCourse(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Test/Create
        public ActionResult CreateTest(int id)
        {
            return View(new Test { CourseId = id, Id = Guid.NewGuid() });
        }

        // POST: Test/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTest(
                                            [Bind("Id,Name,Description,Questions,CourseId")] Test test)
        {
            if (ModelState.IsValid)
            {
                await appService.CreateTest(test);
                return RedirectToAction(nameof(IndexTests), new { id = test.CourseId });
            }
            return View(test);
        }

        // GET: Question/Create
        public ActionResult CreateQuestion(Guid id)
        {
            return View(new Question { TestId = id, Id = Guid.NewGuid() });
        }

        // POST: Question/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuestion(
                                                [Bind("Id,Name,Description,Answers,TestId")] Question question)
        {
            if (ModelState.IsValid)
            {
                await appService.CreateQuestion(question);
                return RedirectToAction(nameof(IndexQuestions), new { id = question.TestId });
            }
            return View(question);
        }

        // GET: Answer/Create
        public ActionResult CreateAnswer(Guid id)
        {
            return View(new Answer { QuestionId = id, Id = Guid.NewGuid() });
        }

        // POST: Answer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAnswer(
                                                [Bind("Id,Name,QuestionId,isRight")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                await appService.CreateAnswer(answer);
                return RedirectToAction(nameof(IndexAnswers), new { id = answer.QuestionId });
            }
            return View(answer);
        }

        // GET: Course/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await appService.GetCourse(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: Course/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
                                             [Bind("Id,Name,Tests")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await appService.UpdateCourse(course);

                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Test/Edit/
        public async Task<IActionResult> EditTest(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await appService.GetTest(id);
            if (test == null)
            {
                return NotFound();
            }
            return View(test);
        }

        // POST: Test/Edit/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTest(Guid id,
                                            [Bind("Id,Name,Description,Questions,CourseId")] Test test)
        {
            if (id != test.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await appService.UpdateTest(test);

                return RedirectToAction(nameof(IndexTests), new { id = test.CourseId });
            }
            return View(test);
        }

        // GET: Question/Edit/
        public async Task<IActionResult> EditQuestion(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await appService.GetQuestion(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: Test/Edit/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditQuestion(Guid id,
                                            [Bind("Id,Name,Description,Answers,TestId")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await appService.UpdateQuestion(question);

                return RedirectToAction(nameof(IndexQuestions), new { id = question.TestId });
            }
            return View(question);
        }

        // GET: Answer/Edit/
        public async Task<IActionResult> EditAnswer(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await appService.GetAnswer(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: Answer/Edit/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAnswer(Guid id,
                                            [Bind("Id,Name,QuestionId,isRight")] Answer answer)
        {
            if (id != answer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await appService.UpdateAnswer(answer);

                return RedirectToAction(nameof(IndexAnswers), new { id = answer.QuestionId });
            }
            return View(answer);
        }

        // GET: Course/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await appService.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Course/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (Course.Equals == null)
            {
                return Problem("Entity set 'ApplicationContext.Employee'  is null.");
            }
            await appService.RemoveCourse(id);

            return RedirectToAction(nameof(Index));
        }

        // GET: Test/Delete
        public async Task<IActionResult> DeleteTest(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await appService.GetTest(id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: Test/Delete
        [HttpPost, ActionName("DeleteTest")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTestConfirmed(Guid? id)
        {
            if (Test.Equals == null)
            {
                return Problem("Entity set 'ApplicationContext.Children'  is null.");
            }
            var result = await appService.GetTest(id);
            await appService.RemoveTest(id);

            return RedirectToAction(nameof(IndexTests), new { id = result.CourseId });
        }

        // GET: Question/Delete
        public async Task<IActionResult> DeleteQuestion(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await appService.GetTest(id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: Question/Delete
        [HttpPost, ActionName("DeleteQuestion")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteQuestionConfirmed(Guid? id)
        {
            if (Question.Equals == null)
            {
                return Problem("Entity set 'ApplicationContext.Children'  is null.");
            }
            var result = await appService.GetQuestion(id);
            await appService.RemoveQuestion(id);

            return RedirectToAction(nameof(IndexQuestions), new { id = result.TestId });
        }

        // GET: Answer/Delete
        public async Task<IActionResult> DeleteAnswer(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await appService.GetAnswer(id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: Answer/Delete
        [HttpPost, ActionName("DeleteAnswer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAnswerConfirmed(Guid? id)
        {
            if (Question.Equals == null)
            {
                return Problem("Entity set 'ApplicationContext.Children'  is null.");
            }
            var result = await appService.GetAnswer(id);
            await appService.RemoveAnswer(id);

            return RedirectToAction(nameof(IndexQuestions), new { id = result.QuestionId });
        }
    }
}