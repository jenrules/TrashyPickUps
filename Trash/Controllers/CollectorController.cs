using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trash.Models;

namespace Trash.Controllers
{
    public class CollectorController : Controller
    {
        private CustomerDBContext db = new CustomerDBContext();

        // GET: Collector
        public ActionResult Index()
        {
            var collectors = db.Collectors.Include(c => c.Customer);
            return View(collectors.ToList());
        }

        // GET: Collector/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collector collector = db.Collectors.Find(id);
            if (collector == null)
            {
                return HttpNotFound();
            }
            return View(collector);
        }

        // GET: Collector/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "LastName");
            return View();
        }

        // POST: Collector/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Route,CustomerID")] Collector collector)
        {
            if (ModelState.IsValid)
            {
                db.Collectors.Add(collector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "LastName", collector.CustomerID);
            return View(collector);
        }

        // GET: Collector/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collector collector = db.Collectors.Find(id);
            if (collector == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "LastName", collector.CustomerID);
            return View(collector);
        }

        // POST: Collector/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Route,CustomerID")] Collector collector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "LastName", collector.CustomerID);
            return View(collector);
        }

        // GET: Collector/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collector collector = db.Collectors.Find(id);
            if (collector == null)
            {
                return HttpNotFound();
            }
            return View(collector);
        }

        // POST: Collector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Collector collector = db.Collectors.Find(id);
            db.Collectors.Remove(collector);
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
