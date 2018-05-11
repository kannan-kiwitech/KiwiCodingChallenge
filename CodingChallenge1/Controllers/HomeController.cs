using CodingChallenge1.Models;
using System.Web.Mvc;
using System.Linq;

namespace CodingChallenge1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index(string state, string city, string zip, int? bedrooms, int? bathrooms)
        {


            var properties = _dbContext.Properties.Take(10).ToList();
            return View(properties);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}