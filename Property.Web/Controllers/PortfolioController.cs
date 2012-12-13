using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Property.Web.Models.Landlord;
using Property.Web.Models;

namespace Property.Web.Controllers
{
    public class PortfolioController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Portfolio/

        public ActionResult Index()
        {
            return View(db.Portfolios.Where(p => p.Owner.UserName == User.Identity.Name).ToList());
        }

        //
        // GET: /Portfolio/Details/5

        public ActionResult Details(int id = 0)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        //
        // GET: /Portfolio/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Portfolio/Create

        [HttpPost]
        public ActionResult Create(PortfolioCreationDto portfolioParams)
        {
            if (ModelState.IsValid)
            {
                var currentUser = db.UserProfiles.Single(u => u.UserName == User.Identity.Name);
                var portfolio = new Portfolio { Name = portfolioParams.Name, Owner = currentUser };
                db.Portfolios.Add(portfolio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portfolioParams);
        }

        //
        // GET: /Portfolio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        //
        // POST: /Portfolio/Edit/5

        [HttpPost]
        public ActionResult Edit(Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portfolio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolio);
        }

        //
        // GET: /Portfolio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        //
        // POST: /Portfolio/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            db.Portfolios.Remove(portfolio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }

    public class PortfolioCreationDto
    {
        [Required]
        public string Name { get; set; }
    }
}