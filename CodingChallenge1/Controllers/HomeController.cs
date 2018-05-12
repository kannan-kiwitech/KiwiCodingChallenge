using CodingChallenge1.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

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
                    Price = p.Price,
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
                    Price = p.Price,
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
            ViewBag.Message = "KiwiTech Code Challenge";
            return View();
        }

        [Authorize]
        public ActionResult Favourites()
        {
            ViewBag.Message = "Your favourite properties.";

            var currentUserId = User.Identity.GetUserId();
            if (currentUserId != null)
            {
                var model = _dbContext.UserFavourites.Where(a => a.UserId == currentUserId).Select(p => new PropertyViewModel
                {
                    Address = p.Property.Address,
                    Bathrooms = p.Property.Bathrooms,
                    Bedrooms = p.Property.Bedrooms,
                    City = p.Property.City,
                    Country = p.Property.Country,
                    ImageUrl = p.Property.ImageUrl,
                    Id = p.Property.Id,
                    Price = p.Property.Price,
                    Latitude = p.Property.Latitude,
                    Longitude = p.Property.Longitude,
                    Name = p.Property.Name,
                    State = p.Property.State,
                    ZipCode = p.Property.ZipCode,
                    IsFavourite = true
                });
                return View(model);
            }
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
            ViewBag.Message = "";
            return View();
        }
    }
}