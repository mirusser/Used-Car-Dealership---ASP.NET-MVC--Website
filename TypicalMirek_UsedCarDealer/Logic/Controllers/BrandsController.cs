using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;
using TypicalMirek_UsedCarDealer.Models.Enums;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class BrandsController : Controller
    {
        private IBrandManager brandManager;

        public BrandsController(IManagerFactory managerFactory)
        {
            brandManager = managerFactory.Get<BrandManager>();
        }
        // GET: Brands
        public ActionResult List()
        {
            return View(brandManager.GetAll().ToList());
        }

        // GET: Brands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var brand = brandManager.GetById(Convert.ToInt32(id));
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: Brands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //TODO what if brand exist in database
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                if (brandManager.Add(brand) == null)
                {
                    return View(brand);
                }
                return View("List", brandManager.GetAll().ToList());
            }

            return View(brand);
        }

        // GET: Brands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var brand = brandManager.GetById(Convert.ToInt32(id));
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //TODO what if brand doesn't exist in database
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                if (brandManager.Modify(brand) == null)
                {
                    return View(brand);
                }
                return View("List", brandManager.GetAll().ToList());
            }
            return View(brand);
        }

        // GET: Brands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var brand = brandManager.GetById(Convert.ToInt32(id));
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var brand = brandManager.GetById(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            brandManager.Delete(brand);
            return View("List", brandManager.GetAll().ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                brandManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
