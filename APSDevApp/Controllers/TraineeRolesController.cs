using System.Linq;
using System.Web.Mvc;
using APSDevApp.Models;
using Microsoft.AspNet.Identity;
using APSDevApp.ViewModels;
using System.Data.Entity;





namespace APSDevApp.Controllers
{
    [Authorize(Roles = "trainee")]
    public class TraineeRolesController : Controller
    {

        // GET: TraineeRoles
        private ApplicationDbContext _context;
        public TraineeRolesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult ViewProfile()
        {
            var userIdCurrent = User.Identity.GetUserId();
            var userInWeb = _context.Users.SingleOrDefault(u => u.Id == userIdCurrent);

            var traineeInWeb = _context.Trainees.SingleOrDefault(t => t.TraineeId == userInWeb.Id);
            var traineeInfor = new UserProfile()
            {
                UserInWeb = userInWeb,
                TraineeInWeb = traineeInWeb
            };
            return View(traineeInfor);


        }
        public ActionResult ViewCourse()
        {
            var userIdCurrent = User.Identity.GetUserId();
            var userInWeb = _context.Users.SingleOrDefault(u => u.Id == userIdCurrent);
            var traineeInWeb = _context.Trainees.SingleOrDefault(t => t.TraineeId == userInWeb.Id);
            var courseTrainee = _context.Courses.SingleOrDefault(c => c.Id == traineeInWeb.CourseId);
            var courses = _context.Courses.Include(c => c.Category).ToList();
            var traineeInfor = new UserProfile()
            {
                UserInWeb = userInWeb,
                TraineeInWeb = traineeInWeb
            };
            return View(courseTrainee);
        }

    }
}