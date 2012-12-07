using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.WebPages.OAuth;
using Property.Web.Models;
using WebMatrix.WebData;

namespace Property.Web.Controllers
{
    [Authorize]
    public class PersonalDetailsController : Controller
    {
        private UsersContext db = new UsersContext();

        public ActionResult Index()
        {
            var personaldetails = db.PersonalDetails.SingleOrDefault(p => p.Profile.UserName == User.Identity.Name) 
                                   ??
                                  PersonalDetails.Default("test@test.com");
            return View("Edit", personaldetails);
        }

        //
        // GET: /PersonalDetails/Details/5

        public ActionResult Details(int id = 0)
        {
            PersonalDetails personaldetails = db.PersonalDetails.Find(id);
            if (personaldetails == null)
            {
                return HttpNotFound();
            }
            return View(personaldetails);
        }

        //
        // GET: /PersonalDetails/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PersonalDetails/Create

        [HttpPost]
        public ActionResult Create(PersonalDetails personaldetails)
        {
            if (ModelState.IsValid)
            {
                db.PersonalDetails.Add(personaldetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personaldetails);
        }

        //
        // GET: /PersonalDetails/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PersonalDetails personaldetails = db.PersonalDetails.Find(id);
            if (personaldetails == null)
            {
                return HttpNotFound();
            }
            return View(personaldetails);
        }

        //
        // POST: /PersonalDetails/Edit/5

        [HttpPost]
        public ActionResult Edit(PersonalDetails personaldetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personaldetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personaldetails);
        }

        //
        // GET: /PersonalDetails/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PersonalDetails personaldetails = db.PersonalDetails.Find(id);
            if (personaldetails == null)
            {
                return HttpNotFound();
            }
            return View(personaldetails);
        }

        //
        // POST: /PersonalDetails/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalDetails personaldetails = db.PersonalDetails.Find(id);
            db.PersonalDetails.Remove(personaldetails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}