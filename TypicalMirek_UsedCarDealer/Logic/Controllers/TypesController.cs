using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Controllers.Strings;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models.ViewModels;
using Type = TypicalMirek_UsedCarDealer.Models.Type;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class TypesController : Controller
    {
        #region Properties
        private readonly ITypeManager typeManager;
        #endregion

        #region Constructors
        public TypesController(IManagerFactory managerFactory)
        {
            typeManager = managerFactory.Get<TypeManager>();
        }
        #endregion

        // GET: Types
        public ActionResult List()
        {
            return View(typeManager.GetAll().ToList());
        }

        // GET: Types/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var type = typeManager.GetById(Convert.ToInt32(id));
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        // GET: Types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Types/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Type type)
        {
            if (ModelState.IsValid)
            {
                if (typeManager.Add(type) == null)
                {
                    ModelState.AddModelError(string.Empty, ControllerStrings.NameIsTaken);
                    return View(type);
                }
                return RedirectToAction($"List");
            }

            return View(type);
        }

        // GET: Types/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var type = typeManager.GetById(Convert.ToInt32(id));
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        // POST: Types/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Type type)
        {
            if (ModelState.IsValid)
            {
                if (typeManager.Modify(type) == null)
                {
                    ModelState.AddModelError(string.Empty, ControllerStrings.NameIsTaken);
                    return View(type);
                }
                return RedirectToAction($"List");
            }
            return View(type);
        }

        // GET: Types/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var type = typeManager.GetById(Convert.ToInt32(id));
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        // POST: Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var type = typeManager.GetById(id);
            if (typeManager.Delete(type))
            {
                return RedirectToAction($"List");
            }
            return HttpNotFound();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                typeManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
