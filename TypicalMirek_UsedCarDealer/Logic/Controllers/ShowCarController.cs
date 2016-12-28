using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class ShowCarController : Controller
    {
        private readonly ICarManager carManager;

        public ShowCarController(IManagerFactory managerFactory)
        {
            carManager = managerFactory.Get<CarManager>();
        }
        // GET: ShowCar
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var car = carManager.GetCarById(Convert.ToInt32(id));

            if (car == null)
            {
                return HttpNotFound();
            }

            carManager.IncrementNumberOfViews(Convert.ToInt32(id));

            return View(car);
        }
    }
}