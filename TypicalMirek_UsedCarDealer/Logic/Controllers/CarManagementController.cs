﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class CarManagementController : Controller
    {
        private readonly ICarManager carManager;

        public CarManagementController(IManagerFactory managerFactory)
        {
            carManager = managerFactory.Get<CarManager>();
        }

        // GET: CarManagement
        public ActionResult List()
        {
            var cars = carManager.GetAllCarsToDisplay();
            return View(cars.ToList());
        }

        // GET: CarManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var car = carManager.GetCarDetailsViewModelById(Convert.ToInt32(id));
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: CarManagement/Create
        public ActionResult Create()
        {
            var carToAdd = carManager.CreateAddCarViewModel();        
            return View(carToAdd);
        }

        //// POST: CarManagement/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddCarViewModel car)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var file in car.Files)
                    {
                        if (file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            if (fileName != null)
                            {
                                var path = Path.Combine(Server.MapPath("~/App_Data/Images"), fileName);
                                file.SaveAs(path);
                            }
                        }
                    }
                    carManager.Add(car);
                    return View("List", carManager.GetAllCarsToDisplay());
                }
                catch (Exception ex)
                {
                    return View(car);
                }
            }

            return View(car);
        }

        // GET: CarManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var car = carManager.GetAddCarViewModel(Convert.ToInt32(id));
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: CarManagement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddCarViewModel car)
        {
            if (ModelState.IsValid)
            {
                carManager.Modify(car);
                return View("List", carManager.GetAllCarsToDisplay());
            }

            return View(car);
        }

        // GET: CarManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var car = carManager.GetCarById(Convert.ToInt32(id));
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
            //var car = carManager.GetCarById(Convert.ToInt32(id));
            //db.Cars.Remove(car);
            //db.SaveChanges();

            carManager.RemoveCarById(id);
            return View("List", carManager.GetAllCarsToDisplay());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                carManager.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GetCarImage(string imageName)
        {
            var path = Path.Combine(Server.MapPath("~/App_Data/Images"), imageName);
            path = Path.GetFullPath(path);

            return File(path, "image/jpeg/png/PNG/jpg");
        }
    }
}
