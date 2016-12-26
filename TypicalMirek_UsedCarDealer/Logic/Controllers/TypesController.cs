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
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;
using Type = TypicalMirek_UsedCarDealer.Models.Type;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class TypesController : Controller
    {
        private readonly ITypeManager typeManager;

        public TypesController(IManagerFactory managerFactory)
        {
            typeManager = managerFactory.Get<TypeManager>();
        }

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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Type type)
        {
            if (ModelState.IsValid)
            {
                typeManager.Add(type);
                return View("List", typeManager.GetAll().ToList());
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Type type)
        {
            if (ModelState.IsValid)
            {
                typeManager.Modify(type);
                return View("List", typeManager.GetAll().ToList());
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
            typeManager.Delete(type);
            return View("List", typeManager.GetAll().ToList());
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
