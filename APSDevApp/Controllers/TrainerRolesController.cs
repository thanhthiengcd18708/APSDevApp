using System.Linq;
using System.Web.Mvc;
using APSDevApp.Models;
using Microsoft.AspNet.Identity;
using APSDevApp.ViewModels;
using System.Data.Entity;





namespace APSDevApp.Controllers
{
    [Authorize(Roles = "trainer")]
    public class TrainerRolesController : Controller
    {

        // GET: TraineeRoles
        private ApplicationDbContext _context;
        public TrainerRolesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult ViewProfile()
        {
            var userIdCurrent = User.Identity.GetUserId();
            var userInWeb = _context.Users.SingleOrDefault(u => u.Id == userIdCurrent);

            var trainerInWeb = _context.Trainers.SingleOrDefault(t => t.TrainerId == userInWeb.Id);
            var trainerInfor = new UserProfile()
            {
                UserInWeb = userInWeb,
                TrainerInWeb = trainerInWeb
            };
            return View(trainerInfor);

        }
        public ActionResult ViewCourse()
        {
            var userIdCurrent = User.Identity.GetUserId();
            var userInWeb = _context.Users.SingleOrDefault(u => u.Id == userIdCurrent);
            var trainerInWeb = _context.Trainers.SingleOrDefault(t => t.TrainerId == userInWeb.Id);
            if (trainerInWeb == null)
            {

                return RedirectToAction("Index", "Home");
            }

            var courseTrainer = _context.Courses.SingleOrDefault(c => c.Id == trainerInWeb.CourseId);
            var courses = _context.Courses.Include(c => c.Category).ToList();
            var trainerInfor = new UserProfile()
            {
                UserInWeb = userInWeb,
                TrainerInWeb = trainerInWeb
            };
            return View(courseTrainer);
        }
        public ActionResult UpdateTrainerProfile()
        {
            var userIdCurrent = User.Identity.GetUserId();
            ApplicationUser userInWeb = _context.Users.FirstOrDefault(x => x.Id == userIdCurrent);
            var trainerProFi = _context.Trainers.SingleOrDefault(t => t.TrainerId == userInWeb.Id);

            return View(trainerProFi);
        }
        [HttpPost]
        public ActionResult UpdateTrainerProfile(Trainer trainer)
        {
            var trainerProInDb = _context.Trainers.SingleOrDefault(t => t.TrainerId == trainer.TrainerId);
            trainerProInDb.ApplicationUser.FullName = trainer.ApplicationUser.FullName;
            trainerProInDb.PhoneNumber = trainer.PhoneNumber;
            trainerProInDb.WorkingPlace = trainer.WorkingPlace;
            trainerProInDb.Type = trainer.Type;
            _context.SaveChanges();
            return RedirectToAction("ViewProfile");
        }


    }
}