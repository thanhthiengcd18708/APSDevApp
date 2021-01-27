using APSDevApp.Models;
using Microsoft.Ajax.Utilities;
using System.Linq;
using System.Web.Mvc;

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