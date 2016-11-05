using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.SqlServer.Server;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Admin(int? parameter)
        {
            if (parameter == null)
            {
                return View(0);
            }
            return View((int)parameter);
        }
    }
}