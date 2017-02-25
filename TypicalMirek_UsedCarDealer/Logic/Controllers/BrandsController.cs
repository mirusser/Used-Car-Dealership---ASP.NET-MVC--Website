using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Controllers.Strings;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BrandsController : Controller
    {
        #region Properties
        private readonly IBrandManager brandManager;
        #endregion

        #region Constructors
        public BrandsController(IManagerFactory managerFactory)
        {
            brandManager = managerFactory.Get<BrandManager>();
        }
        #endregion

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                if (brandManager.Add(brand) == null)
                {
                    ModelState.AddModelError(string.Empty, ControllerStrings.NameIsTaken);
                    return View(brand);
                }
                return RedirectToAction("List");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                if (brandManager.Modify(brand) == null)
                {
                    ModelState.AddModelError(string.Empty, ControllerStrings.NameIsTaken);
                    return View(brand);
                }
                return RedirectToAction("List");
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

            if (brandManager.Delete(brand))
            {
                return RedirectToAction("List");
            }
            return HttpNotFound();
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
