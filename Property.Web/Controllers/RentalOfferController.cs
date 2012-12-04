using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Property.DomainContracts.Dtos;
using Property.Web.Services;

namespace Property.Web.Controllers
{
    public class RentalOfferController : Controller
    {
        private readonly IAudit _audit;
        private readonly IQueueWriter _queueWriter;

        public RentalOfferController(IAudit audit, IQueueWriter queueWriter)
        {
            _audit = audit;
            _queueWriter = queueWriter;
        }

        public RentalOfferController()
        {
            //delete this once ioc is here
        }

        //
        // GET: /RentalOffer/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /RentalOffer/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /RentalOffer/Create

        public ActionResult Create()
        {

            return View(TenantRentalOffer.CreateDefault());
        }

        //
        // POST: /RentalOffer/Create

        [HttpPost]
        public ActionResult Create(TenantRentalOffer offer)
        {
            try
            {
                //TODO  add and check validation
                _audit.Audit(offer);
                _queueWriter.Enqueue(offer);
                TempData["info"] = "You offer has been submitted";
                return RedirectToAction("Index", "Favourites");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /RentalOffer/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /RentalOffer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /RentalOffer/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /RentalOffer/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
