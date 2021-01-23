using APSDevApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APSDevApp.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Courses
        private ApplicationDbContext _context;
        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Tasks
        public ActionResult Index()
        {
            return View(_context.Categories.ToList());
        }

        public ActionResult Details(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == id);
            return View(categoryInDb);
        }
    }
}