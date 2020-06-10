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
    public class LocatsController : Controller
    {
        private VehicleEntities2 db = new VehicleEntities2();

        // GET: Locats
        public ActionResult Index()
        {
            return View(db.Locats.ToList());
        }

        // GET: Locats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locat locat = db.Locats.Find(id);
            if (locat == null)
            {
                return HttpNotFound();
            }
            return View(locat);
        }

        // GET: Locats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocID,LocDetails")] Locat locat)
        {
            if (ModelState.IsValid)
            {
                db.Locats.Add(locat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locat);
        }

        // GET: Locats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locat locat = db.Locats.Find(id);
            if (locat == null)
            {
                return HttpNotFound();
            }
            return View(locat);
        }

        // POST: Locats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocID,LocDetails")] Locat locat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locat);
        }

        // GET: Locats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locat locat = db.Locats.Find(id);
            if (locat == null)
            {
                return HttpNotFound();
            }
            return View(locat);
        }

        // POST: Locats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locat locat = db.Locats.Find(id);
            db.Locats.Remove(locat);
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
