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
    public class CarModelsController : Controller
    {
        //private TypicalMirekEntities db = new TypicalMirekEntities();

        //// GET: CarModels
        //public ActionResult Index()
        //{
        //    //var models = db.Models.Include(m => m.Brand);
        //    //return View(models.ToList());
        //}

        //// GET: CarModels/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    //Model model = db.Models.Find(id);
        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(model);
        //}

        //// GET: CarModels/Create
        //public ActionResult Create()
        //{
        //    ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name");
        //    return View();
        //}

        //// POST: CarModels/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Version,BrandId")] Model model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Models.Add(model);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", model.BrandId);
        //    return View(model);
        //}

        //// GET: CarModels/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Model model = db.Models.Find(id);
        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", model.BrandId);
        //    return View(model);
        //}

        //// POST: CarModels/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Version,BrandId")] Model model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(model).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", model.BrandId);
        //    return View(model);
        //}

        //// GET: CarModels/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Model model = db.Models.Find(id);
        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(model);
        //}

        //// POST: CarModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Model model = db.Models.Find(id);
        //    db.Models.Remove(model);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
