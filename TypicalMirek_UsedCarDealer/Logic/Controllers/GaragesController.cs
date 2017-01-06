using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TypicalMirek_UsedCarDealer.Logic.Factories;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class GaragesController : Controller
    {
        #region Properties
        private TypicalMirekEntities db = new TypicalMirekEntities();
        private readonly IGarageManager garageManager;
        private string userId => User.Identity.GetUserId();
        #endregion

        public GaragesController(ManagerFactory managerFactory)
        {
            garageManager = managerFactory.Get<GarageManager>();
        }

        // GET: Garages
        public ActionResult Index()
        {
            var userGarage = garageManager.GetGarageByUserId(userId);
            return View(userGarage);
        }

        public ActionResult OrderCar(int carId)
        {
            garageManager.OrderCar(carId,userId);
            return RedirectToAction("Index");
        }

        // GET: Garages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garage garage = db.UserGarage.Find(id);
            if (garage == null)
            {
                return HttpNotFound();
            }
            return View(garage);
        }

        // GET: Garages/Create
        public ActionResult Create()
        {
            ViewBag.UserId = userId;
            return View();
        }

        // POST: Garages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId")] Garage garage)
        {
            if (ModelState.IsValid)
            {
                db.UserGarage.Add(garage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //System.Web.HttpContext.Current.User.Identity.
            ViewBag.UserId = userId;
            return View(garage);
        }

        // GET: Garages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garage garage = db.UserGarage.Find(id);
            if (garage == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = userId;
            return View(garage);
        }

        // POST: Garages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId")] Garage garage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = userId;
            return View(garage);
        }

        // GET: Garages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garage garage = db.UserGarage.Find(id);
            if (garage == null)
            {
                return HttpNotFound();
            }
            return View(garage);
        }

        // POST: Garages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Garage garage = db.UserGarage.Find(id);
            db.UserGarage.Remove(garage);
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
