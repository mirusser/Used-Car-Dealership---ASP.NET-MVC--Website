using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        #region Constructors
        public AdminController()
        {

        }
        #endregion

        // GET: Admin
        public ActionResult Admin(ParametersToAdminMenu parametersToAdminMenu)
        {
            if (ModelState.IsValid)
            {
                if (parametersToAdminMenu.Id == null)
                {
                    parametersToAdminMenu.Id = 0;
                }
                return View(new ParametersToAdminMenu
                {
                    Chose = parametersToAdminMenu.Chose,
                    Id = parametersToAdminMenu.Id
                });
            }

            return View(parametersToAdminMenu);
        }
    }
}