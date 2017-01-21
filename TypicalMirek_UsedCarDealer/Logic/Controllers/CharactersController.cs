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
    public class CharactersController : Controller
    {
        #region Properties
        private readonly ICharacterManager characterManager;
        #endregion

        #region Constructors
        public CharactersController(IManagerFactory managerFactory)
        {
            characterManager = managerFactory.Get<CharacterManager>();
        }
        #endregion

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Character character)
        {
            if (ModelState.IsValid)
            {
                if (characterManager.Add(character) == null)
                {
                    ModelState.AddModelError(string.Empty, ControllerStrings.NameIsTaken);
                    return View(character);
                }
                return RedirectToAction($"List");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Character character)
        {
            if (ModelState.IsValid)
            {
                if (characterManager.Modify(character) == null)
                {
                    ModelState.AddModelError(string.Empty, ControllerStrings.NameIsTaken);
                    return View(character);
                }
                return RedirectToAction($"List");
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
            if (characterManager.Delete(character))
            {
                return RedirectToAction($"List");
            }
            else
            {
                var relatedDataDeleteErrorViewModel = new RelatedDataDeleteErrorViewModel
                {
                    ControllerName = "Characters",
                    ModelName = nameof(Character)
                };
                return View("RelatedDataDeleteError", relatedDataDeleteErrorViewModel);
            }
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
