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
        private readonly ICharacterManager characterManager;
        private readonly IColorRepository colorRepository;
        private readonly IGearboxRepository geargoxRepository;
        private readonly IPropulsionRepository propulsionRepository;
        private readonly IModelRepository modelRepository;


        public CarController(IManagerFactory managerFactory)
        {
            carManager = managerFactory.Get<CarManager>();
            brandManager = managerFactory.Get<BrandManager>();
            sourceOfEnergyRepository = new SourceOfEnergyRepository();
            carBodyManager = managerFactory.Get<CarBodyManager>();
            characterManager = managerFactory.Get<CharacterManager>();
            colorRepository = new ColorRepository();
            geargoxRepository = new GearboxRepository();
            propulsionRepository = new PropulsionRepository();
            modelRepository = new ModelRepository();
        }

        /// <summary>
        /// Used by plugin dependent-dropdown to create Models dropdownlist
        /// when user choosed Brand from first dropdownlist
        /// more info: http://plugins.krajee.com/dependent-dropdown
        /// </summary>
        /// <param name="depdrop_parents">table of string but only one string is used</param>
        /// <param name="depdrop_all_params">associative array of keys and values (it merges the values of
        ///        depdrop_parents and depdrop_params) - to create an array - not used here</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Models(string[] depdrop_parents, IDictionary<string, string> depdrop_all_params)
        {
            string brand = depdrop_parents[0];

            var itemsToDropdown = new ItemsToDependendDropdownViewModel {output = new List<Output>()};
            foreach (var it in modelRepository.GetAll().Where(it => it.Brand.Name == brand).Select(it => it.Name))
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

        public ActionResult CarList(string character = null, string brand = null, string model = null, int? minPrice = null, int? maxPrice = null, string fuel = null, int? yearFrom = null, int? yearTo = null,
            string body = null, int? milleageFrom = null, int? milleageTo = null, bool? damaged = null, int? engineCapacityFrom = null, int? engineCapacityTo = null, int? enginePowerFrom = null, int? enginePowerTo = null,
            string gearbox = null, string propulsion = null, int? numberOfSeats = null, string colour = null, string sortBy = null, int? perPage = null, int? page = null)
        {
            var parametersToCarList = new ParametersToCarList();

            #region Select car dependend from parameters

            //get all cars id which are current and get CarDetailsViewModel by those ids
            var cars = new List<CarDetailsViewModel>();
            foreach (var it in carManager.GetAllCars().Where(it => it.DeleteTime == null))
            {
                cars.Add(carManager.GetCarDetailsViewModelById(it.Id));
            }

            #endregion

            #region character brand model minPrice maxPrice fuel yearFrom yearTo
            if (!string.IsNullOrEmpty(character))
            {
                cars = cars.Where(it => it.Character == character).ToList();
            }

            if (!string.IsNullOrEmpty(brand))
            {
                cars = cars.Where(it => it.Brand == brand).ToList();
            }

            if (!string.IsNullOrEmpty(model))
            {
                cars = cars.Where(it => it.ModelName == model).ToList();
            }

            if (minPrice != null)
            {
                cars = cars.Where(it => it.Price >= minPrice).ToList();
            }

            if (maxPrice != null)
            {
                cars = cars.Where(it => it.Price <= maxPrice).ToList();
            }

            if (!string.IsNullOrEmpty(fuel))
            {
                cars = cars.Where(it => it.SourceOfEnergy == fuel).ToList();
            }

            if (yearFrom != null)
            {
                cars = cars.Where(it => it.YearOfProduction >= yearFrom).ToList();
            }

            if (yearTo != null)
            {
                cars = cars.Where(it => it.YearOfProduction <= yearTo).ToList();
            }
            #endregion

            #region body milleageFrom milleageTo damaged engineCapacityFrom engineCapacityTo enginePowerFrom enginePowerTo
            if (!string.IsNullOrEmpty(body))
            {
                cars = cars.Where(it => it.Body == body).ToList();
            }

            if (milleageFrom != null)
            {
                cars = cars.Where(it => it.YearOfProduction >= milleageFrom).ToList();
            }

            if (milleageTo != null)
            {
                cars = cars.Where(it => it.YearOfProduction <= milleageTo).ToList();
            }

            if (damaged != null)
            {
                cars = cars.Where(it => it.Damaged == damaged).ToList();
            }

            if (engineCapacityFrom != null)
            {
                cars = cars.Where(it => it.EngineCapacity >= engineCapacityFrom).ToList();
            }

            if (engineCapacityTo != null)
            {
                cars = cars.Where(it => it.EngineCapacity <= engineCapacityTo).ToList();
            }

            if (enginePowerFrom != null)
            {
                cars = cars.Where(it => it.EnginePower >= enginePowerFrom).ToList();
            }

            if (enginePowerTo != null)
            {
                cars = cars.Where(it => it.EnginePower <= enginePowerTo).ToList();
            }
            #endregion

            #region gearbox propulsion numberOfSeats colour perPage sortBy
            if (!string.IsNullOrEmpty(gearbox))
            {
                cars = cars.Where(it => it.Gearbox == gearbox).ToList();
            }

            if (!string.IsNullOrEmpty(propulsion))
            {
                cars = cars.Where(it => it.Propulsion == propulsion).ToList();
            }

            if (!string.IsNullOrEmpty(colour))
            {
                cars = cars.Where(it => it.Color == colour).ToList();
            }

            int howManyCarsHasChosen = cars.Count;

            switch (sortBy)
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
            #endregion

            #region pagination, calculate how many pages
            if (perPage == null)
            {
                parametersToCarList.NumberOfPages = Convert.ToInt32(Math.Ceiling(howManyCarsHasChosen / 20.0));
            }
            else
            {
                parametersToCarList.NumberOfPages = Convert.ToInt32(Math.Ceiling(howManyCarsHasChosen / Convert.ToDouble(perPage)));
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


            #region Define BodyList

            parametersToCarList.BodyList = carBodyManager.GetAll().Select(it => it.Name);

            #endregion

            #region Define BrandList

            parametersToCarList.BrandList = brandManager.GetAll().Select(it => it.Name);

            #endregion

            #region Define CharacterList

            parametersToCarList.CharacterList = characterManager.GetAll().Select(it => it.Name);

            #endregion

            #region Define ColourList

            parametersToCarList.ColorList = colorRepository.GetAll().Select(it => it.Name);

            #endregion

            #region Define FuelList

            parametersToCarList.FuelList = sourceOfEnergyRepository.GetAll().Select(it => it.Name);

            #endregion

            #region Define GearboxList

            parametersToCarList.GearboxList = geargoxRepository.GetAll().Select(it => it.Name);

            #endregion

            #region Define NumberOfSeatsList

            parametersToCarList.NumberOfSeatsList = new List<int> { 1, 2, 3, 4, 5, 6 }.AsQueryable();

            #endregion

            #region Define PropulsionList

            parametersToCarList.PropulsionList = propulsionRepository.GetAll().Select(it => it.Name);

            #endregion

            #region Define SortByList

            parametersToCarList.SortByList = new List<string>(new[] { "newFirst", "oldFirst", "priceAscending", "priceDescending", "alphabetical" }).AsQueryable();

            #endregion

            return View(parametersToCarList);
        }
    }
}