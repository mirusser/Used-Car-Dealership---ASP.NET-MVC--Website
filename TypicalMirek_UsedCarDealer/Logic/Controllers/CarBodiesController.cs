using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class CarBodiesController : Controller
    {
        private TypicalMirekEntities db = new TypicalMirekEntities();

        // GET: CarBodies
        public ActionResult List()
        {
            return View(db.Bodies.ToList());
        }

        // GET: CarBodies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Body body = db.Bodies.Find(id);
            if (body == null)
            {
                return HttpNotFound();
            }
            return View(body);
        }

        // GET: CarBodies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarBodies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Body body)
        {
            if (ModelState.IsValid)
            {
                db.Bodies.Add(body);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(body);
        }

        // GET: CarBodies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Body body = db.Bodies.Find(id);
            if (body == null)
            {
                return HttpNotFound();
            }
            return View(body);
        }

        // POST: CarBodies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Body body)
        {
            if (ModelState.IsValid)
            {
                db.Entry(body).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(body);
        }

        // GET: CarBodies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Body body = db.Bodies.Find(id);
            if (body == null)
            {
                return HttpNotFound();
            }
            return View(body);
        }

        // POST: CarBodies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Body body = db.Bodies.Find(id);
            db.Bodies.Remove(body);
            db.SaveChanges();
            return RedirectToAction("List");
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
