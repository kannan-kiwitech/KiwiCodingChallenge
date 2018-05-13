using CodingChallenge1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingChallenge1.Controllers
{
    public class PropertyController : Controller
    {
        private ApplicationDbContext _dbContext;

        public PropertyController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Route("Property/{propertyId}")]
        public ActionResult Index(Guid propertyId)
        {
            var property = _dbContext.Properties.Find(propertyId);
            return View(property);
        }
    }
}