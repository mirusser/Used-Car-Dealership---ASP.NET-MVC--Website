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

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ICharacterManager characterManager;

        public CharactersController(IManagerFactory managerFactory)
        {
            characterManager = managerFactory.Get<CharacterManager>();
        }

        // GET: Characters
        public ActionResult List()
        {
            return View(characterManager.GetAll().ToList());
        }

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var character = characterManager.GetById(Convert.ToInt32(id));
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Character character)
        {
            if (ModelState.IsValid)
            {
                characterManager.Add(character);
                return View("List", characterManager.GetAll().ToList());
            }

            return View(character);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var character = characterManager.GetById(Convert.ToInt32(id));
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Character character)
        {
            if (ModelState.IsValid)
            {
                characterManager.Modify(character);
                return View("List", characterManager.GetAll().ToList());
            }
            return View(character);
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var character = characterManager.GetById(Convert.ToInt32(id));
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var character = characterManager.GetById(id);
            characterManager.Delete(character);
            return View("List", characterManager.GetAll().ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                characterManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
