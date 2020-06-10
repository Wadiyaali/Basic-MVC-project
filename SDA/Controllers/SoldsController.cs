using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDA.Models;

namespace SDA.Controllers
{
    public class SoldsController : Controller
    {
        private VehicleEntities2 db = new VehicleEntities2();

        // GET: Solds
        public ActionResult Index()
        {
            var solds = db.Solds.Include(s => s.Locat).Include(s => s.Vehicle).Include(s => s.Tracker);
            return View(solds.ToList());
        }

        // GET: Solds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sold sold = db.Solds.Find(id);
            if (sold == null)
            {
                return HttpNotFound();
            }
            return View(sold);
        }

        // GET: Solds/Create
        public ActionResult Create()
        {
            ViewBag.LocID = new SelectList(db.Locats, "LocID", "LocDetails");
            ViewBag.AppID = new SelectList(db.Vehicles, "AppID", "VehicleDet");
            ViewBag.TrackerID = new SelectList(db.Trackers, "TrackerID", "Statuss");
            return View();
        }

        // POST: Solds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleID,TrackerID,LocID,AppID,Validate")] Sold sold)
        {
            if (ModelState.IsValid)
            {
                db.Solds.Add(sold);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocID = new SelectList(db.Locats, "LocID", "LocDetails", sold.LocID);
            ViewBag.AppID = new SelectList(db.Vehicles, "AppID", "VehicleDet", sold.AppID);
            ViewBag.TrackerID = new SelectList(db.Trackers, "TrackerID", "Statuss", sold.TrackerID);
            return View(sold);
        }

        // GET: Solds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sold sold = db.Solds.Find(id);
            if (sold == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocID = new SelectList(db.Locats, "LocID", "LocDetails", sold.LocID);
            ViewBag.AppID = new SelectList(db.Vehicles, "AppID", "VehicleDet", sold.AppID);
            ViewBag.TrackerID = new SelectList(db.Trackers, "TrackerID", "Statuss", sold.TrackerID);
            return View(sold);
        }

        // POST: Solds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleID,TrackerID,LocID,AppID,Validate")] Sold sold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sold).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocID = new SelectList(db.Locats, "LocID", "LocDetails", sold.LocID);
            ViewBag.AppID = new SelectList(db.Vehicles, "AppID", "VehicleDet", sold.AppID);
            ViewBag.TrackerID = new SelectList(db.Trackers, "TrackerID", "Statuss", sold.TrackerID);
            return View(sold);
        }

        // GET: Solds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sold sold = db.Solds.Find(id);
            if (sold == null)
            {
                return HttpNotFound();
            }
            return View(sold);
        }

        // POST: Solds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sold sold = db.Solds.Find(id);
            db.Solds.Remove(sold);
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
