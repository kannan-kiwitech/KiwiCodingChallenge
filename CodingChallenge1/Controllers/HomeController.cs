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


            var properties = _dbContext.Properties.AsQueryable();

            if (zip != null)
            {
                properties = properties.Where(a => a.ZipCode.Contains(zip));
            }
            if (state != null)
            {
                properties = properties.Where(a => a.State.Contains(state));
            }
            if (city != null)
            {
                properties = properties.Where(a => a.City.Contains(city));
            }
            if (bedrooms != null)
            {
                properties = properties.Where(a => a.Bedrooms == bedrooms);
            }
            if (bathrooms != null)
            {
                properties = properties.Where(a => a.Bathrooms == bathrooms);
            }

            properties = properties.Take(10);


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