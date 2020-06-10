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
    public class TrackersController : Controller
    {
        private VehicleEntities2 db = new VehicleEntities2();

        // GET: Trackers
        public ActionResult Index()
        {
            var trackers = db.Trackers.Include(t => t.returned);
            return View(trackers.ToList());
        }

        // GET: Trackers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracker tracker = db.Trackers.Find(id);
            if (tracker == null)
            {
                return HttpNotFound();
            }
            return View(tracker);
        }

        // GET: Trackers/Create
        public ActionResult Create()
        {
            ViewBag.TrackerID = new SelectList(db.returneds, "trackerID", "Reason");
            return View();
        }

        // POST: Trackers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrackerID,Statuss,Details,Sales,Validate")] Tracker tracker)
        {
            if (ModelState.IsValid)
            {
                db.Trackers.Add(tracker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrackerID = new SelectList(db.returneds, "trackerID", "Reason", tracker.TrackerID);
            return View(tracker);
        }

        // GET: Trackers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracker tracker = db.Trackers.Find(id);
            if (tracker == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrackerID = new SelectList(db.returneds, "trackerID", "Reason", tracker.TrackerID);
            return View(tracker);
        }

        // POST: Trackers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrackerID,Statuss,Details,Sales,Validate")] Tracker tracker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tracker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrackerID = new SelectList(db.returneds, "trackerID", "Reason", tracker.TrackerID);
            return View(tracker);
        }

        // GET: Trackers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracker tracker = db.Trackers.Find(id);
            if (tracker == null)
            {
                return HttpNotFound();
            }
            return View(tracker);
        }

        // POST: Trackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tracker tracker = db.Trackers.Find(id);
            db.Trackers.Remove(tracker);
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
