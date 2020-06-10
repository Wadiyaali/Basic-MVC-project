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
    public class returnedsController : Controller
    {
        private VehicleEntities2 db = new VehicleEntities2();

        // GET: returneds
        public ActionResult Index()
        {
            var returneds = db.returneds.Include(r => r.Tracker);
            return View(returneds.ToList());
        }

        // GET: returneds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            returned returned = db.returneds.Find(id);
            if (returned == null)
            {
                return HttpNotFound();
            }
            return View(returned);
        }

        // GET: returneds/Create
        public ActionResult Create()
        {
            ViewBag.trackerID = new SelectList(db.Trackers, "TrackerID", "Statuss");
            return View();
        }

        // POST: returneds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "trackerID,Reason")] returned returned)
        {
            if (ModelState.IsValid)
            {
                db.returneds.Add(returned);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.trackerID = new SelectList(db.Trackers, "TrackerID", "Statuss", returned.trackerID);
            return View(returned);
        }

        // GET: returneds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            returned returned = db.returneds.Find(id);
            if (returned == null)
            {
                return HttpNotFound();
            }
            ViewBag.trackerID = new SelectList(db.Trackers, "TrackerID", "Statuss", returned.trackerID);
            return View(returned);
        }

        // POST: returneds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "trackerID,Reason")] returned returned)
        {
            if (ModelState.IsValid)
            {
                db.Entry(returned).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.trackerID = new SelectList(db.Trackers, "TrackerID", "Statuss", returned.trackerID);
            return View(returned);
        }

        // GET: returneds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            returned returned = db.returneds.Find(id);
            if (returned == null)
            {
                return HttpNotFound();
            }
            return View(returned);
        }

        // POST: returneds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            returned returned = db.returneds.Find(id);
            db.returneds.Remove(returned);
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
