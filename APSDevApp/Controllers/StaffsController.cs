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