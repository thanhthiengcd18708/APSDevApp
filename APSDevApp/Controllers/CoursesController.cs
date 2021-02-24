using APSDevApp.Models;
using APSDevApp.ViewModels;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
namespace APSDevApp.Controllers
{
    [Authorize(Roles = "staff")]
    public class CoursesController : Controller
    {
        // GET: Courses
        private ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Tasks
        public ActionResult Index(string searchString)
        {
            var courses = _context.Courses.Include(c => c.Category).ToList();

            if (!searchString.IsNullOrWhiteSpace())
            {
                courses = _context.Courses
                    .Where(c => c.Name.Contains(searchString) || c.Description.Contains(searchString))
                    .ToList();
            }
            return View(courses);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var Models = new CourseCategoriesViewModel()
            {
                Categories = _context.Categories.ToList()
            };
            return View(Models);
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {

            if (course.CategoryId == null)
            {
                return RedirectToAction("Create");
            }

            var checkCourse = _context.Courses.Where(t => t.Name == course.Name);

            if (checkCourse.Count() > 0)
            {
                return RedirectToAction("Create");
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            else
            {
                var newCourse = new Course()
                {
                    Name = course.Name,
                    Description = course.Description,
                    IsAvailable = course.IsAvailable,
                    CategoryId = course.CategoryId

                };
                _context.Courses.Add(newCourse);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {

            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);
            var courses = _context.Courses.Include(c => c.Category).ToList();
            return View(courseInDb);
        }
        public ActionResult Update(int id)
        {
            var taskInDb = _context.Courses.SingleOrDefault(t => t.Id == id);
            if (taskInDb == null) return HttpNotFound();
            var viewModel = new CourseCategoriesViewModel()
            {
                Course = taskInDb,
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Update(Course course)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CourseCategoriesViewModel()
                {
                    Course = course,
                    Categories = _context.Categories.ToList()
                };
                return View(viewModel);
            }
            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == course.Id);
            courseInDb.Name = course.Name;
            courseInDb.Description = course.Description;
            courseInDb.CategoryId = course.CategoryId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);
            if (courseInDb == null) return HttpNotFound();
            var trainer = _context.Trainers.Where(t => t.CourseId == id);
            foreach (var item in trainer)
            {
                item.course = null;
                item.CourseId = null;
            }
            var trainee = _context.Trainees.Where(t => t.CourseId == id);
            foreach (var item in trainee)
            {
                item.course = null;
                item.CourseId = null;

            }
            _context.Courses.Remove(courseInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}