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
    [Authorize(Roles = "Admin")]
    public class EmailConfigurationsController : Controller
    {
        private readonly IEmailConfigurationManager emailConfigurationManager;

        public EmailConfigurationsController(IManagerFactory managerFactory)
        {
            emailConfigurationManager = managerFactory.Get<EmailConfigurationManager>();
        }

        // GET: EmailConfigurations
        public ActionResult Index()
        {
            return View(emailConfigurationManager.GetAll());
        }

        // GET: EmailConfigurations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmailConfigurations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password,Host,Port,EnableSsl,From,To,Active")] EmailConfiguration emailConfiguration)
        {
            if (ModelState.IsValid)
            {
                emailConfigurationManager.Add(emailConfiguration);
                return RedirectToAction("Index");
            }

            return View(emailConfiguration);
        }

        // GET: EmailConfigurations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmailConfiguration emailConfiguration = emailConfigurationManager.GetById(Convert.ToInt32(id));

            if (emailConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(emailConfiguration);
        }

        // POST: EmailConfigurations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Password,Host,Port,EnableSsl,From,To,Active")] EmailConfiguration emailConfiguration)
        {
            if (ModelState.IsValid)
            {
                emailConfigurationManager.Modify(emailConfiguration);
                return RedirectToAction("Index");
            }
            return View(emailConfiguration);
        }

        // GET: EmailConfigurations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var emailConfiguration = emailConfigurationManager.GetById(Convert.ToInt32(id));

            if (emailConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(emailConfiguration);
        }

        // POST: EmailConfigurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmailConfiguration emailConfiguration = emailConfigurationManager.GetById(Convert.ToInt32(id));
            emailConfigurationManager.Delete(emailConfiguration);
            return RedirectToAction("Index");
        }

        public ActionResult SetActive(int id)
        {
            emailConfigurationManager.SetActive(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                emailConfigurationManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
