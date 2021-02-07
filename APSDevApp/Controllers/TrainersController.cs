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
    public class TrainersController : Controller
    {


        public ApplicationDbContext _context;
        public TrainersController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(string searchInput)
        {
            var trainers = _context.Trainers.ToList();

            if (!searchInput.IsNullOrWhiteSpace())
            {
                trainers = _context.Trainers
                     .Where(c => c.ApplicationUser.FullName.Contains(searchInput)
                     || c.WorkingPlace.Contains(searchInput))
                     .ToList();
            }
            return View(trainers);
        }
        public ActionResult Details(string id)
        {
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.TrainerId == id);
            return View(trainerInDb);
        }

        public ActionResult Update(string id)
        {
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.TrainerId == id);
            if (trainerInDb == null)
            {
                return HttpNotFound();
            }
            return View(trainerInDb);
        }
        [HttpPost]
        public ActionResult Update(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.TrainerId == trainer.TrainerId);
            {
                trainerInDb.ApplicationUser.FullName = trainer.ApplicationUser.FullName;
                trainerInDb.PhoneNumber = trainer.PhoneNumber;
                trainerInDb.WorkingPlace = trainer.WorkingPlace;
                trainerInDb.Type = trainer.Type;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);     
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.TrainerId == id);
            if (userInDb == null)
            {

                return HttpNotFound();
            }


            if (trainerInDb == null)
            {
                return HttpNotFound();
            }
            _context.Trainers.Remove(trainerInDb);
            _context.Users.Remove(userInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}