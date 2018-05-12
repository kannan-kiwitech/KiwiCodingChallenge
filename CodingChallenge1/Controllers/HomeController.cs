using CodingChallenge1.Models;
using System.Web.Mvc;
using System.Linq;
using System;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

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

            IQueryable<PropertyViewModel> propertyViewModel;
            var currentUserId = User.Identity.GetUserId();
            if (currentUserId == null)
            {
                propertyViewModel = properties.Select(p => new PropertyViewModel
                {
                    Address = p.Address,
                    Bathrooms = p.Bathrooms,
                    Bedrooms = p.Bedrooms,
                    City = p.City,
                    Country = p.Country,
                    ImageUrl = p.ImageUrl,
                    Id = p.Id,
                    Latitude = p.Latitude,
                    Longitude = p.Longitude,
                    Name = p.Name,
                    State = p.State,
                    ZipCode = p.ZipCode,
                    IsFavourite = false
                });
            }
            else
            {
                var favourites = _dbContext.UserFavourites.Where(a => a.UserId == currentUserId).Select(a => a.PropertyId).ToList();

                propertyViewModel = properties.Select(p => new PropertyViewModel
                {
                    Address = p.Address,
                    Bathrooms = p.Bathrooms,
                    Bedrooms = p.Bedrooms,
                    City = p.City,
                    Country = p.Country,
                    ImageUrl = p.ImageUrl,
                    Id = p.Id,
                    Latitude = p.Latitude,
                    Longitude = p.Longitude,
                    Name = p.Name,
                    State = p.State,
                    ZipCode = p.ZipCode,
                    IsFavourite = favourites.Contains(p.Id)
                });

            }

            return View(propertyViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [Authorize]
        public ActionResult Favourite(Guid propertyId)
        {
            var currentUserId = User.Identity.GetUserId();
            if (currentUserId != null)
            {
                var property = _dbContext.Properties.Find(propertyId);
                if (property != null)
                {
                    var favourite = _dbContext.UserFavourites.Where(a => a.UserId == currentUserId && a.PropertyId == propertyId).FirstOrDefault();

                    if (favourite == null)
                    {
                        var userFavourite = new UserFavourites
                        {
                            UserId = currentUserId,
                            PropertyId = propertyId
                        };
                        _dbContext.UserFavourites.Add(userFavourite);
                        _dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        _dbContext.UserFavourites.Remove(favourite);
                        _dbContext.SaveChangesAsync();
                    }

                }

                ViewBag.Message = "Your application description page.";
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}