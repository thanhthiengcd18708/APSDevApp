using APSDevApp.Models;
using APSDevApp.ViewModels;
using Microsoft.Ajax.Utilities;
using System.Linq;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace APSDevApp.Controllers
{
    public class TraineesController : Controller
    {
        private ApplicationDbContext _context;
        public TraineesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Trainees
        public ActionResult Index(string searchString)
        {
            var traineesInDb = _context.Trainees.ToList();
            return View(traineesInDb);
        }
        public ActionResult UpdateProfile()
        {
            return View();
        }

    }
}