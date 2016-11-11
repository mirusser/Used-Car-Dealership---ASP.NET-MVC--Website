using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.SqlServer.Server;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICarManager carManager;

        public AdminController(IManagerFactory managerFactory)
        {
            carManager = managerFactory.Get<CarManager>();
        }

        // GET: Admin
        public ActionResult Admin(int? parameter)
        {
            if (parameter == null)
            {
                return View(0);
            }
            return View((int)parameter);
        }

        public ActionResult CreateCar()
        {
            var carToAdd = carManager.CreateAddCarViewModel();
            return View(carToAdd);
        }

        public ActionResult ShowCarList()
        {
            var cars = carManager.GetAllCarsToDisplay();
            return View(cars.ToList());
        }
    }
}