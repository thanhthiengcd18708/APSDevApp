using APSDevApp.Models;
using APSDevApp.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace APSDevApp.Controllers
{
    [Authorize(Roles = "admin,staff")]
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
        [Authorize(Roles = "admin")]
        public ActionResult Index(string searchInput)
        {
            var staffs = _context.Staffs.ToList();

            if (!searchInput.IsNullOrWhiteSpace())
            {
                staffs = _context.Staffs
                     .Where(s => s.ApplicationUser.UserName.Contains(searchInput))
                     .ToList();
            }
            return View(staffs);
        }
        [Authorize(Roles = "admin")]
        public ActionResult Update(string id)
        {
            var staffInDb = _context.Staffs.SingleOrDefault(t => t.StaffId == id);
            if (staffInDb == null)
            {
                return HttpNotFound();
            }
            return View(staffInDb);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Update(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var staffInDb = _context.Staffs.SingleOrDefault(s => s.StaffId == staff.StaffId);
            {
                staffInDb.ApplicationUser.FullName = staff.ApplicationUser.FullName;
                staffInDb.Location = staff.Location;
                staffInDb.Age = staff.Age;
                staffInDb.DayOfBirthday = staff.DayOfBirthday;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin")]
        public ActionResult Delete(string id)
        {
            var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);
            var staffInDb = _context.Staffs.SingleOrDefault(s => s.StaffId == id);
            if (userInDb == null)
            {

                return HttpNotFound();
            }
            if (staffInDb == null)
            {
                return HttpNotFound();
            }
            _context.Staffs.Remove(staffInDb);
            _context.Users.Remove(userInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}