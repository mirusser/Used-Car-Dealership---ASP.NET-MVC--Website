using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class ColorsController : Controller
    {
        private readonly IColorManager colorManager;

        public ColorsController(IManagerFactory managerFactory)
        {
            colorManager = managerFactory.Get<ColorManager>();
        }

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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Color color)
        {
            if (ModelState.IsValid)
            {
                if (colorManager.Add(color) != null)
                {
                    return View("List", colorManager.GetAll().ToList());
                };

                ModelState.AddModelError(string.Empty, "Color already exists.");
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Color color)
        {
            if (ModelState.IsValid)
            {
                if (colorManager.Modify(color) != null)
                {
                    return View("List", colorManager.GetAll().ToList());
                }
                ModelState.AddModelError(string.Empty, "Color with that name already exists.");
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
            if (colorManager.Delete(color))
            {
                return View("List", colorManager.GetAll().ToList());
            }

            ModelState.AddModelError(string.Empty, "Color is assigned to one or more car and cannot be deleted.");
            return View(color);
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
