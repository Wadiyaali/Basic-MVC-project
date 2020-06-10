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
    public class TrackertypesController : Controller
    {
        private VehicleEntities2 db = new VehicleEntities2();

        // GET: Trackertypes
        public ActionResult Index()
        {
            var trackertypes = db.Trackertypes.Include(t => t.Tracker);
            return View(trackertypes.ToList());
        }

        // GET: Trackertypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trackertype trackertype = db.Trackertypes.Find(id);
            if (trackertype == null)
            {
                return HttpNotFound();
            }
            return View(trackertype);
        }

        // GET: Trackertypes/Create
        public ActionResult Create()
        {
            ViewBag.TrackerID = new SelectList(db.Trackers, "TrackerID", "Statuss");
            return View();
        }

        // POST: Trackertypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "typeID,TrackerID,NoofSale")] Trackertype trackertype)
        {
            if (ModelState.IsValid)
            {
                db.Trackertypes.Add(trackertype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrackerID = new SelectList(db.Trackers, "TrackerID", "Statuss", trackertype.TrackerID);
            return View(trackertype);
        }

        // GET: Trackertypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trackertype trackertype = db.Trackertypes.Find(id);
            if (trackertype == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrackerID = new SelectList(db.Trackers, "TrackerID", "Statuss", trackertype.TrackerID);
            return View(trackertype);
        }

        // POST: Trackertypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "typeID,TrackerID,NoofSale")] Trackertype trackertype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trackertype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrackerID = new SelectList(db.Trackers, "TrackerID", "Statuss", trackertype.TrackerID);
            return View(trackertype);
        }

        // GET: Trackertypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trackertype trackertype = db.Trackertypes.Find(id);
            if (trackertype == null)
            {
                return HttpNotFound();
            }
            return View(trackertype);
        }

        // POST: Trackertypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trackertype trackertype = db.Trackertypes.Find(id);
            db.Trackertypes.Remove(trackertype);
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
