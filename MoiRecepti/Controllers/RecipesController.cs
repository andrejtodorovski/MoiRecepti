using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoiRecepti.Models;

namespace MoiRecepti.Controllers
{
    public class RecipesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Recipes
        public ActionResult Index()
        {
            return View(db.Recipes.ToList());
        }
        // GET: Breakfast
        public ActionResult Breakfast()
        {
            return View(db.Recipes.ToList().FindAll(r=>r.Vid.Equals("Доручек")));
        }
        // GET: Side
        public ActionResult Side()
        {
            return View(db.Recipes.ToList().FindAll(r => r.Vid.Equals("Предјадење")));
        }
        // GET: Main
        public ActionResult Main()
        {
            return View(db.Recipes.ToList().FindAll(r => r.Vid.Equals("Главно јадење")));
        }
        // GET: Dessert
        public ActionResult Dessert()
        {
            return View(db.Recipes.ToList().FindAll(r => r.Vid.Equals("Десерт")));
        }
        // GET: MyRecipes
        public ActionResult MyRecipes()
        {
            return View(db.Recipes.ToList().FindAll(r => r.UserEmail.Equals(User.Identity.Name)));
        }
        // GET: Review
        public ActionResult Review(int id)
        {
            Review review = new Review
            {
                RecipeID = id
            };
            return View(review);
        }
        // POST: Review
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Review([Bind(Include = "ID,Rating,Comment,RecipeID")] Review review)
        {
            if (ModelState.IsValid)
            {
                review.UserEmail = User.Identity.Name;
                review.TimeCreated = DateTime.Now;
                db.Reviews.Add(review);
                Recipe recipe = db.Recipes.Find(review.RecipeID);
                recipe.Reviews.Add(review);
                db.SaveChanges();
                int num = db.Reviews.ToList().FindAll(r => r.RecipeID == review.RecipeID).Count;
                int sum = db.Reviews.ToList().FindAll(r => r.RecipeID == review.RecipeID).Sum(r=>r.Rating);
                Console.WriteLine(num);
                Console.WriteLine(sum);
                recipe.AverageRating = (float) sum/num;
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            recipe.TotalViews = recipe.TotalViews + 1;
            db.Entry(recipe).State = EntityState.Modified;
            db.SaveChanges();
            if (User.Identity.Name.Equals(recipe.UserEmail)) {
                ViewBag.Boolean = false;
            }
            else if (db.Reviews.ToList().FindAll(r=>r.UserEmail.Equals(User.Identity.Name) && r.RecipeID == recipe.ID).Count != 0)
            {
                ViewBag.Boolean = false;
            }
            else
            {
                ViewBag.Boolean = true;
            }
            return View(recipe);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            ViewBag.Vidovi = new List<SelectListItem>
            {
                new SelectListItem {Text = "Доручек", Value = "Доручек"},
                new SelectListItem {Text = "Предјадење", Value = "Предјадење"},
                new SelectListItem {Text = "Главно јадење", Value = "Главно јадење"},
                new SelectListItem {Text = "Десерт", Value = "Десерт"}
            };
            ViewBag.Kompleksnosti = new List<SelectListItem>
            {
                new SelectListItem {Text = "Ниско", Value = "Ниско"},
                new SelectListItem {Text = "Средно", Value = "Средно"},
                new SelectListItem {Text = "Високо", Value = "Високо"}
            };
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,Sostojki,Alergeni,Opis,Vid,NivoNaTezina,ZaKolkuLica,VremePodgotovka,Slika")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.UserEmail = User.Identity.Name;
                recipe.AverageRating = 0;
                recipe.TotalViews = 0;
                recipe.Reviews = new List<Review>();
                recipe.TimeCreated = DateTime.Now;
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vidovi = new List<SelectListItem>
            {
                new SelectListItem {Text = "Доручек", Value = "Доручек"},
                new SelectListItem {Text = "Предјадење", Value = "Предјадење"},
                new SelectListItem {Text = "Главно јадење", Value = "Главно јадење"},
                new SelectListItem {Text = "Десерт", Value = "Десерт"}
            };
            ViewBag.Kompleksnosti = new List<SelectListItem>
            {
                new SelectListItem {Text = "Ниско", Value = "Ниско"},
                new SelectListItem {Text = "Средно", Value = "Средно"},
                new SelectListItem {Text = "Високо", Value = "Високо"}
            };
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Sostojki,Alergeni,Opis,Vid,NivoNaTezina,ZaKolkuLica,VremePodgotovka,Slika,UserEmail,AverageRating,TotalViews")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.TimeCreated = DateTime.Now;
                recipe.UserEmail = User.Identity.Name;
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
