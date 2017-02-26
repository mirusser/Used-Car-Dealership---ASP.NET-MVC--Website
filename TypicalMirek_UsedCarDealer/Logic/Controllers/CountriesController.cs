using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Controllers.Strings;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountriesController : Controller
    {
        #region Properties
        private readonly ICountryManager countryManager;
        #endregion

        #region Cnstructors
        public CountriesController(IManagerFactory managerFactory)
        {
            countryManager = managerFactory.Get<CountryManager>();
        }
        #endregion

        public ActionResult List()
        {
            return View(countryManager.GetAll().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var country = countryManager.GetById(Convert.ToInt32(id));
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                if (countryManager.Add(country) != null)
                {
                    return RedirectToAction($"List");
                };

                ModelState.AddModelError(string.Empty, ControllerStrings.NameIsTaken);
            }

            return View(country);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var country = countryManager.GetById(Convert.ToInt32(id));
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                if (countryManager.Modify(country) == null)
                {
                    ModelState.AddModelError(string.Empty, ControllerStrings.NameIsTaken);
                    return View(country);
                }
                return RedirectToAction($"List");
            }
            return View(country);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var country = countryManager.GetById(Convert.ToInt32(id));
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var country = countryManager.GetById(Convert.ToInt32(id));
            countryManager.Delete(country);
            return RedirectToAction($"List");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                countryManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
