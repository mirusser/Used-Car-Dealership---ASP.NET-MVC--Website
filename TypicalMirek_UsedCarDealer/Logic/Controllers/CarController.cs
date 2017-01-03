using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarManager carManager;

        public CarController(IManagerFactory managerFactory)
        {
            carManager = managerFactory.Get<CarManager>();
        }

        // GET: ShowCar
        public ActionResult ShowCar(int? id)
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

        public ActionResult CarList(string orderBy = null, int? minPrice = null, int? maxPrice = null, string brand = null, string model = null, int? page = null, int? perPage = null)
        {
            var cars = new List<CarDetailsViewModel>();

            foreach (var it in carManager.GetAllCars().Where(it => it.DeleteTime == null))
            {
                cars.Add(carManager.GetCarDetailsViewModelById(it.Id));
            }

            switch (orderBy)
            {
                case "newFirst":
                    cars = cars.OrderBy(it => it.AddTime).ToList();
                    break;
                case "oldFirst":
                    cars = cars.OrderByDescending(it => it.AddTime).ToList();
                    break;
                case "priceAscending":
                    cars = cars.OrderBy(it => it.Price).ToList();
                    break;
                case "priceDescending":
                    cars = cars.OrderByDescending(it => it.Price).ToList();
                    break;
                case "alphabetical":
                    cars = cars.OrderBy(it => it.Brand + it.ModelName).ToList();
                    break;
                default:
                    cars = cars.OrderBy(it => it.AddTime).ToList();
                    break;
            }

            if (minPrice != null)
            {
                cars = cars.Where(it => it.Price >= minPrice).ToList();
            }

            if (maxPrice != null)
            {
                cars = cars.Where(it => it.Price <= maxPrice).ToList();
            }

            if (!string.IsNullOrEmpty(brand))
            {
                cars = cars.Where(it => it.Brand == brand).ToList();
            }

            if (!string.IsNullOrEmpty(model))
            {
                cars = cars.Where(it => it.ModelName == model).ToList();
            }

            if (page != null && perPage != null)
            {
                if (cars.Count() >= page*perPage)
                {
                    cars = cars.Skip(Convert.ToInt32(page * perPage)).ToList();
                }
                if (cars.Count() > perPage)
                {
                    cars = cars.Take(Convert.ToInt32(perPage)).ToList();
                }
            }
            else if (page != null && perPage == null)
            {
                if (cars.Count() >= page * 20)
                {
                    cars = cars.Skip(Convert.ToInt32(page * 20)).ToList();
                }
                if (cars.Count() > 20)
                {
                    cars = cars.Take(Convert.ToInt32(20)).ToList();
                }
            }
            else if (page == null && perPage != null)
            {
                cars = cars.Take(Convert.ToInt32(perPage)).ToList();
            }

            return View(cars);
        }
    }
}