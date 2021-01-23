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
        List<Course> _courses = new List<Course>
        {
            new Course (1,"GCD" ,"asds"),
            new Course (2, "GBD","adddd"),
            new Course( 3,"GED","adad" )
        };
        // GET: Tasks
        public ActionResult Index()
        {
            return View(_courses);
        }

        public ActionResult Details(int id)
        {
            Course courseInDb = _courses.SingleOrDefault(t => t.Id == id);
            return View(courseInDb);
        }
    }
}