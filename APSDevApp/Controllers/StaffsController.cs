using APSDevApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APSDevApp.Controllers
{
    public class StaffsController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public StaffsController()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext())
            );
        }
        // GET: Staffs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Delete(string id)
        {
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.TrainerId == id);
            _context.Trainers.Remove(trainerInDb);
            _context.Users.Remove(_userManager.FindById(id));
            _context.SaveChanges();
            return View();
        }
    }
}