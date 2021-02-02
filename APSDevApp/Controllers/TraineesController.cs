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
        public ApplicationDbContext _context;
        public TraineesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(string searchString)
        {
            var trainees = _context.Trainees.ToList();

            if (!searchString.IsNullOrWhiteSpace())
            {
                trainees = _context.Trainees
                     .Where(c => c.ApplicationUser.FullName.Contains(searchString))
                     .ToList();
            }
            return View(trainees);
        }
        public ActionResult Details(string id)
        {
            var traineeInDb = _context.Trainees.SingleOrDefault(t => t.TraineeId == id);
            return View(traineeInDb);
        }

        public ActionResult Update(string id)
        {
            var traineeInDb = _context.Trainees.SingleOrDefault(t => t.TraineeId == id);
            if (traineeInDb == null)
            {
                return HttpNotFound();
            }
            return View(traineeInDb);
        }
        [HttpPost]
        public ActionResult Update(Trainee trainee)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var traineeInDb = _context.Trainees.SingleOrDefault(t => t.TraineeId == trainee.TraineeId);
            {
                traineeInDb.ApplicationUser.FullName = trainee.ApplicationUser.FullName;
                traineeInDb.Age = trainee.Age;
                traineeInDb.DayOfBirthday = trainee.DayOfBirthday;
                traineeInDb.Education = trainee.Education;
                traineeInDb.ProgramingLanguage = trainee.ProgramingLanguage;
                traineeInDb.ToeicScore = trainee.ToeicScore;
                traineeInDb.Location = trainee.Location;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            var traineeInDb = _context.Trainees.SingleOrDefault(t => t.TraineeId == id);

            if (traineeInDb == null) return HttpNotFound();

            _context.Trainees.Remove(traineeInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}