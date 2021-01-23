﻿using APSDevApp.Models;
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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid) return View();
            var newCategory = new Category()
            {
                Name = category.Name,
                Dc = category.Dc,

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
    }
}