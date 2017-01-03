using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
    public class HomeController : Controller
    {
        private readonly ISliderPhotoManager sliderPhotoManager;
        private readonly ICarManager carManager;

        public HomeController(IManagerFactory managerFactory)
        {
            sliderPhotoManager = managerFactory.Get<SliderPhotoManager>();
            carManager = managerFactory.Get<CarManager>();
        }

        public ActionResult Index()
        {
            ParametersToHome parameters = new ParametersToHome
            {
                Slider = new List<CarPhotoViewModel>(),
                HotCars = new List<CarPhotoViewModel>(),
                NewCars = new List<CarPhotoViewModel>()
            };

            foreach (var it in sliderPhotoManager.GetAllSlides())
            {
                parameters.Slider.Add(new CarPhotoViewModel
                {
                    imageName = sliderPhotoManager.GetName(it.CarPhotoId),
                    description = it.Car.MainData.Model.Brand.Name + " " + it.Car.MainData.Model.Name,
                    carId = it.Car.Id,
                    price = it.Car.Price
                });
            }

            var hotCars = carManager.GetAllCars().Where(it => it.Photos.Count > 0 && it.DeleteTime == null).OrderByDescending(it => it.numberOfViews).Take(8);

            foreach (var it in hotCars)
            {
                parameters.HotCars.Add(new CarPhotoViewModel
                {
                    imageName = it.Photos.First().Name,
                    description = it.MainData.Model.Brand.Name + " " + it.MainData.Model.Name,
                    carId = it.Id,
                    price = it.Price
                });
            }

            var newCars = carManager.GetAllCars().Where(it => it.Photos.Count > 0 && it.DeleteTime == null).OrderByDescending(it => it.AddTime).Take(8);
            foreach (var it in newCars)
            {
                parameters.NewCars.Add(new CarPhotoViewModel
                {
                    imageName = it.Photos.First().Name,
                    description = it.MainData.Model.Brand.Name + " " + it.MainData.Model.Name,
                    carId = it.Id,
                    price = it.Price
                });
            }

            return View(parameters);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}