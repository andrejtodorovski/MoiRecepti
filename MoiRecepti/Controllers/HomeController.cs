using MoiRecepti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoiRecepti.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            HomePageView hpv = new HomePageView
            {
                TopRated = db.Recipes.ToList().OrderByDescending(r => r.AverageRating).ToList().Take(5).ToList(),
                MostVisited = db.Recipes.ToList().OrderByDescending(r => r.TotalViews).ToList().Take(5).ToList(),
                Newest = db.Recipes.ToList().OrderByDescending(r => r.TimeCreated).ToList().Take(5).ToList(),
            };
            return View(hpv);
        }

        public ActionResult Recipes()
        {
            return View();
        }
        public ActionResult MyReviews()
        {
            return View(db.Reviews.ToList().FindAll(r => r.UserEmail.Equals(User.Identity.Name)));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Податоци за компанијата";

            return View();
        }
    }
}