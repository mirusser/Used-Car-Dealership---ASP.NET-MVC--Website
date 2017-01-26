using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class MarkersConfigurationsController : Controller
    {
        private readonly IMarkersConfigurationManager markersConfigurationManager;

        public MarkersConfigurationsController(IManagerFactory managerFactory)
        {
            markersConfigurationManager = managerFactory.Get<MarkersConfigurationManager>();
        }

        // GET: MarkersConfigurations
        public ActionResult Index()
        {
            var markersConfiguration = markersConfigurationManager.GetAll();

            return View(markersConfiguration);
        }

        // GET: MarkersConfigurations/Create
        public ActionResult CreateMarker()
        {
            return View();
        }

        // POST: MarkersConfigurations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMarker([Bind(Include = "Id,Latitude,Longitude,Title,Info")] MarkersConfiguration markersConfiguration)
        {
            if (ModelState.IsValid)
            {
                markersConfiguration.IsMarker = true;

                markersConfigurationManager.AddMarker(markersConfiguration);

                return RedirectToAction("Index");
            }

            return View(markersConfiguration);
        }

        // GET: MarkersConfigurations/Edit/5
        public ActionResult EditMarker(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkersConfiguration markersConfiguration = markersConfigurationManager.GetAllMarkers().FirstOrDefault(it => it.Id == id);

            if (markersConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(markersConfiguration);
        }

        // POST: MarkersConfigurations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMarker([Bind(Include = "Id,Latitude,Longitude,Title,Info")] MarkersConfiguration markersConfiguration)
        {
            if (ModelState.IsValid)
            {
                markersConfiguration.IsMarker = true;

                markersConfigurationManager.ModifyMarker(markersConfiguration);

                return RedirectToAction("Index");
            }
            return View(markersConfiguration);
        }

        // GET: MarkersConfigurations/CreateOrEditMapLocalization
        public ActionResult CreateOrEditMapLocalization()
        {
            var mapLocalization = markersConfigurationManager.GetMapLocalization();

            return View(mapLocalization);
        }

        // POST: MarkersConfigurations/CreateOrEditMapLocalization
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrEditMapLocalization([Bind(Include = "Id,Latitude,Longitude,Title,Info")] MarkersConfiguration markersConfiguration)
        {
            markersConfiguration.IsMarker = false;

            markersConfigurationManager.AddOrModifyMapLocalization(markersConfiguration);

            return RedirectToAction("Index");
        }

        // GET: MarkersConfigurations/Delete/5
        public ActionResult DeleteMarker(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkersConfiguration markersConfiguration = markersConfigurationManager.GetMarkerById(Convert.ToInt32(id));
            if (markersConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(markersConfiguration);
        }

        // POST: MarkersConfigurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMarkerConfirmed(int id)
        {
            MarkersConfiguration markersConfiguration = markersConfigurationManager.GetMarkerById(id);
            markersConfigurationManager.DeleteMarker(markersConfiguration);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                markersConfigurationManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
