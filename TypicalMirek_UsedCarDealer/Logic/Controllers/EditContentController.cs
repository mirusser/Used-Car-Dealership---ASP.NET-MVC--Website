using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class EditContentController : Controller
    {
        private readonly IWebsiteContextManager websiteContextManager;

        public EditContentController(IManagerFactory managerFactory)
        {
            websiteContextManager = managerFactory.Get<WebsiteContextManager>();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditAbout()
        {
            var context = websiteContextManager.GetContextByName("About");

            var parameters = new ParametersToWysiwyg
            {
                Context = context?.Context,
                SiteName = "About"
            };

            return View(parameters);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult EditContact()
        {
            var context = websiteContextManager.GetContextByName("Contact");

            var parameters = new ParametersToWysiwyg
            {
                Context = context?.Context,
                SiteName = "Contact"
            };

            return View(parameters);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditFooter()
        {
            var context = websiteContextManager.GetContextByName("Footer");

            var parameters = new ParametersToWysiwyg
            {
                Context = context?.Context,
                SiteName = "Footer"
            };

            return View(parameters);
        }
    }
}