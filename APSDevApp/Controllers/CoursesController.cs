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

        public ActionResult Details(int id)
        {
            Course courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);
            return View(courseInDb);
        }
    }
}