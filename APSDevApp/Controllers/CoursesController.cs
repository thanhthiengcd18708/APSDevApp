using APSDevApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
        public ActionResult Index()
        {
            return View(_context.Courses.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (!ModelState.IsValid) return View();
            var newCourse = new Course()
            {
                Name = course.Name,
                Dc = course.Dc,
                
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

    }
}