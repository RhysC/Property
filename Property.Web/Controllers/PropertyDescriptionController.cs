using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Property.Web.Models.Landlord;
using Property.Web.Models;

namespace Property.Web.Controllers
{
    public class PropertyDescriptionController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /PropertyDescription/Details/5
        public ActionResult Details(int id = 0)
        {
            PropertyDescription propertydescription = db.PropertyDescriptions.Find(id);
            if (propertydescription == null)
            {
                return HttpNotFound();
            }
            return View(propertydescription);
        }

        //
        // GET: /PropertyDescription/Create

        public ActionResult Create(int portfolioId)
        {
            return View();
        }

        //
        // POST: /PropertyDescription/Create

        [HttpPost]
        public ActionResult Create(int portfolioId, PropertyDescription propertydescription)
        {
            if (ModelState.IsValid)
            {
                db.Portfolios.Find(portfolioId).Properties.Add(propertydescription);
                //db.PropertyDescriptions.Add(propertydescription);
                db.SaveChanges();
                return RedirectToAction("Details", "Portfolio", new { id = portfolioId });
            }
            return View();//todo - look at this?
        }

        //
        // GET: /PropertyDescription/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PropertyDescription propertydescription = db.PropertyDescriptions.Find(id);
            if (propertydescription == null)
            {
                return HttpNotFound();
            }
            return View(propertydescription);
        }

        //
        // POST: /PropertyDescription/Edit/5

        [HttpPost]
        public ActionResult Edit(PropertyDescription propertydescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertydescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propertydescription);
        }

        //
        // GET: /PropertyDescription/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PropertyDescription propertydescription = db.PropertyDescriptions.Find(id);
            if (propertydescription == null)
            {
                return HttpNotFound();
            }
            return View(propertydescription);
        }

        //
        // POST: /PropertyDescription/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyDescription propertydescription = db.PropertyDescriptions.Find(id);
            db.PropertyDescriptions.Remove(propertydescription);
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