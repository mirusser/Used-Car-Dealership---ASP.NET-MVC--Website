using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarManager carManager;
        private readonly IBrandManager brandManager;
        private readonly ISourceOfEnergyRepository sourceOfEnergyRepository;
        private readonly ICarBodyManager carBodyManager;

        public CarController(IManagerFactory managerFactory)
        {
            carManager = managerFactory.Get<CarManager>();
            brandManager = managerFactory.Get<BrandManager>();
            sourceOfEnergyRepository = new SourceOfEnergyRepository();
            carBodyManager = managerFactory.Get<CarBodyManager>();
        }

        /// <summary>
        /// Used by plugin dependent-dropdown to create Models dropdownlist
        /// when user choosed Brand from first dropdownlist
        /// more info: http://plugins.krajee.com/dependent-dropdown
        /// </summary>
        /// <param name="depdrop_parents">table of string but onlyone string is used</param>
        /// <param name="depdrop_all_params">associative array of keys and values (it merges the values of depdrop_parents and depdrop_params) - to create an array</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Models(string[] depdrop_parents, Dictionary<string, string> depdrop_all_params)
        {
            string brand = depdrop_parents[0];

            var itemsToDropdown = new ItemsToDependendDropdownViewModel {output = new List<Output>()};
            foreach (var it in carManager.GetAllCars().Where(it => it.MainData.Model.Brand.Name == brand).Select(it => it.MainData.Model.Name).Distinct())
            {
                itemsToDropdown.output.Add(new Output {id = it, name = it});
            }
            var firstOrDefault = itemsToDropdown.output.FirstOrDefault();
            if (firstOrDefault != null) itemsToDropdown.selected = firstOrDefault.id;

            return Json(itemsToDropdown, JsonRequestBehavior.AllowGet);
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

        public ActionResult CarList(string orderBy = null, int? minPrice = null, int? maxPrice = null, int? minYear = null, int? maxYear = null, string brand = null, string model = null, string fuel = null, string body = null, int? page = null, int? perPage = null)
        {
            var parametersToCarList = new ParametersToCarList();

            #region Sort Car List
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

            parametersToCarList.SortByList = new List<string>(new [] { "newFirst", "oldFirst", "priceAscending", "priceDescending", "alphabetical" });

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

            if (!string.IsNullOrEmpty(fuel))
            {
                cars = cars.Where(it => it.SourceOfEnergy == fuel).ToList();
            }

            if (!string.IsNullOrEmpty(body))
            {
                cars = cars.Where(it => it.Body == body).ToList();
            }

            if (minYear != null)
            {
                cars = cars.Where(it => it.YearOfProduction >= minYear).ToList();
            }

            if (maxYear != null)
            {
                cars = cars.Where(it => it.YearOfProduction <= maxYear).ToList();
            }
            #endregion

            #region Add brand list

            parametersToCarList.BrandList = brandManager.GetAll().Select(it => it.Name);

            #endregion

            #region Add model list

            if (!string.IsNullOrEmpty(brand))
            {
                parametersToCarList.ModelList = carManager.GetAllCars().Where(it => it.MainData.Model.Brand.Name == brand).Select(it => it.MainData.Model.Name).Distinct();
            }

            #endregion

            #region Number of pages and current page and paginate car list

            if (page == null)
            {
                parametersToCarList.CurrentPage = 0;
            }
            else
            {
                parametersToCarList.CurrentPage = Convert.ToInt32(page);
            }

            if (perPage == null)
            {
                parametersToCarList.NumberOfPages = Convert.ToInt32(Math.Ceiling(cars.Count / 20.0));
            }
            else
            {
                parametersToCarList.NumberOfPages = Convert.ToInt32(Math.Ceiling(cars.Count / Convert.ToDouble(perPage)));
            }

            if (page != null && perPage != null)
            {
                if (cars.Count() >= page * perPage)
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
            parametersToCarList.Cars = cars;

            #endregion

            #region Add Fuel Types

            parametersToCarList.FuelList = sourceOfEnergyRepository.GetAll().Select(it => it.Name);

            #endregion

            #region Add Body Types

            parametersToCarList.BodyList = carBodyManager.GetAll().Select(it => it.Name);

            #endregion

            return View(parametersToCarList);
        }
    }
}