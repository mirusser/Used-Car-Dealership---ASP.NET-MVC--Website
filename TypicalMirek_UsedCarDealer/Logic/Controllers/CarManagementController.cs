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
    public class CarManagementController : Controller
    {
        private TypicalMirekEntities db = new TypicalMirekEntities();

        // GET: CarManagement
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.AdditionalData).Include(c => c.Body).Include(c => c.MainData).Include(c => c.Propulsion).Include(c => c.SourceOfEnergy);
            return View(cars.ToList());
        }

        // GET: CarManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: CarManagement/Create
        public ActionResult Create()
        {
            ViewBag.AdditionalDataId = new SelectList(db.AdditionalDatas, "Id", "Id");
            ViewBag.BodyId = new SelectList(db.Bodies, "Id", "Name");
            ViewBag.MainDataId = new SelectList(db.MainDatas, "Id", "Id");
            ViewBag.PropulsionId = new SelectList(db.Propulsions, "Id", "Name");
            ViewBag.SourceOfEnergyId = new SelectList(db.SourcesOfEnergie, "Id", "Name");
            return View();
        }

        // POST: CarManagement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MainDataId,BodyId,PropulsionId,SourceOfEnergyId,AdditionalDataId")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdditionalDataId = new SelectList(db.AdditionalDatas, "Id", "Id", car.AdditionalDataId);
            ViewBag.BodyId = new SelectList(db.Bodies, "Id", "Name", car.BodyId);
            ViewBag.MainDataId = new SelectList(db.MainDatas, "Id", "Id", car.MainDataId);
            ViewBag.PropulsionId = new SelectList(db.Propulsions, "Id", "Name", car.PropulsionId);
            ViewBag.SourceOfEnergyId = new SelectList(db.SourcesOfEnergie, "Id", "Name", car.SourceOfEnergyId);
            return View(car);
        }

        // GET: CarManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdditionalDataId = new SelectList(db.AdditionalDatas, "Id", "Id", car.AdditionalDataId);
            ViewBag.BodyId = new SelectList(db.Bodies, "Id", "Name", car.BodyId);
            ViewBag.MainDataId = new SelectList(db.MainDatas, "Id", "Id", car.MainDataId);
            ViewBag.PropulsionId = new SelectList(db.Propulsions, "Id", "Name", car.PropulsionId);
            ViewBag.SourceOfEnergyId = new SelectList(db.SourcesOfEnergie, "Id", "Name", car.SourceOfEnergyId);
            return View(car);
        }

        // POST: CarManagement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MainDataId,BodyId,PropulsionId,SourceOfEnergyId,AdditionalDataId")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdditionalDataId = new SelectList(db.AdditionalDatas, "Id", "Id", car.AdditionalDataId);
            ViewBag.BodyId = new SelectList(db.Bodies, "Id", "Name", car.BodyId);
            ViewBag.MainDataId = new SelectList(db.MainDatas, "Id", "Id", car.MainDataId);
            ViewBag.PropulsionId = new SelectList(db.Propulsions, "Id", "Name", car.PropulsionId);
            ViewBag.SourceOfEnergyId = new SelectList(db.SourcesOfEnergie, "Id", "Name", car.SourceOfEnergyId);
            return View(car);
        }

        // GET: CarManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: CarManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
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
