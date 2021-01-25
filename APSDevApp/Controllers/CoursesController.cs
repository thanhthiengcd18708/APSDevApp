using APSDevApp.Models;
using Microsoft.Ajax.Utilities;
using System.Linq;
using System.Web.Mvc;
namespace APSDevApp.Controllers
{
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
            var courses = _context.Courses.ToList();
            if (!searchString.IsNullOrWhiteSpace())
            {
                courses = _context.Courses
                    .Where(c => c.Name.Contains(searchString))
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
            if (!ModelState.IsValid) return View();
            var newCourse = new Course()
            {
                CategoryId = course.CategoryId,
                Name = course.Name,
                Dc = course.Dc

            };
            _context.Courses.Add(newCourse);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);
            return View(courseInDb);
        }
        public ActionResult Update(int id)
        {
            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);
            if (courseInDb == null) return HttpNotFound();
            return View(courseInDb);
        }
        [HttpPost]
        public ActionResult Update(Course course)
        {

            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == course.Id);
            courseInDb.Name = course.Name;
            courseInDb.Dc = course.Dc;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);
            if (courseInDb == null) return HttpNotFound();
            _context.Courses.Remove(courseInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}