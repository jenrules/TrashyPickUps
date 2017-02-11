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
    public class PaymentController : Controller
    {
        private CustomerDBContext db = new CustomerDBContext();

        // GET: Payment
        public ActionResult Index()
        {
            var paymentModels = db.PaymentModels.Include(p => p.Customer);
            return View(paymentModels.ToList());
        }

        // GET: Payment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentModel paymentModel = db.PaymentModels.Find(id);
            if (paymentModel == null)
            {
                return HttpNotFound();
            }
            return View(paymentModel);
        }

        // GET: Payment/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "LastName");
            return View();
        }

        // POST: Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Payment,CustomerID")] PaymentModel paymentModel)
        {
            if (ModelState.IsValid)
            {
                db.PaymentModels.Add(paymentModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "LastName", paymentModel.CustomerID);
            return View(paymentModel);
        }

        // GET: Payment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentModel paymentModel = db.PaymentModels.Find(id);
            if (paymentModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "LastName", paymentModel.CustomerID);
            return View(paymentModel);
        }

        // POST: Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Payment,CustomerID")] PaymentModel paymentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "LastName", paymentModel.CustomerID);
            return View(paymentModel);
        }

        // GET: Payment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentModel paymentModel = db.PaymentModels.Find(id);
            if (paymentModel == null)
            {
                return HttpNotFound();
            }
            return View(paymentModel);
        }

        // POST: Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentModel paymentModel = db.PaymentModels.Find(id);
            db.PaymentModels.Remove(paymentModel);
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
