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
    public class ColorsController : Controller
    {
        #region Properties
        private readonly IColorManager colorManager;
        #endregion

        #region Controlers
        public ColorsController(IManagerFactory managerFactory)
        {
            colorManager = managerFactory.Get<ColorManager>();
        }
        #endregion

        // GET: Colors
        public ActionResult List()
        {
            return View(colorManager.GetAll().ToList());
        }

        // GET: Colors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var color = colorManager.GetById(Convert.ToInt32(id));
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // GET: Colors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Color color)
        {
            if (ModelState.IsValid)
            {
                if (colorManager.Add(color) != null)
                {
                    return RedirectToAction($"List");
                };

                ModelState.AddModelError(string.Empty, ControllerStrings.NameIsTaken);
            }

            return View(color);
        }

        // GET: Colors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var color = colorManager.GetById(Convert.ToInt32(id));
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // POST: Colors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Color color)
        {
            if (ModelState.IsValid)
            {
                if (colorManager.Modify(color) == null)
                {
                    ModelState.AddModelError(string.Empty, ControllerStrings.NameIsTaken);
                    return View(color);
                }
                return RedirectToAction($"List");
            }
            return View(color);
        }

        // GET: Colors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var color = colorManager.GetById(Convert.ToInt32(id));
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // POST: Colors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var color = colorManager.GetById(Convert.ToInt32(id));
            colorManager.Delete(color);
            return RedirectToAction($"List");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                colorManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
