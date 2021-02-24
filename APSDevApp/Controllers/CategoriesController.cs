﻿using APSDevApp.Models;
using Microsoft.Ajax.Utilities;
using System.Linq;
using System.Web.Mvc;

namespace APSDevApp.Controllers
{
    [Authorize(Roles = "staff")]
    public class CategoriesController : Controller
    {
        // GET: Courses
        private ApplicationDbContext _context;
        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Tasks
        public ActionResult Index(string searchString)
        {
            var categories = _context.Categories.ToList();
            if (!searchString.IsNullOrWhiteSpace())
            {
                categories = _context.Categories
                    .Where(c => c.Name.Contains(searchString))
                    .ToList();
            }
            return View(categories);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }
            var checkCategory = _context.Categories.Where(t => t.Name == category.Name);
            if (checkCategory.Count() > 0)
            {

                return RedirectToAction("Index");
            }
            var newCategory = new Category()
            {
                Name = category.Name,
                Description = category.Description
            };
            _context.Categories.Add(newCategory);

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == id);
            return View(categoryInDb);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == id);
            if (categoryInDb == null) return HttpNotFound();
            return View(categoryInDb);
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {

            var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == category.Id);
            categoryInDb.Name = category.Name;
            categoryInDb.Description = category.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == id);
            if (categoryInDb == null)

            {
                return RedirectToAction("Index");
            }
            var course = _context.Courses.Where(t => t.CategoryId == id);

            if (course.Count() > 0)
            {
                return RedirectToAction("Index");
            }
            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}