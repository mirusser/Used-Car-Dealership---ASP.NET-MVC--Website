using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

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
                Slider = new List<ImageInfo>(),
                HotCars = new List<ImageInfo>()
            };

            foreach (var it in sliderPhotoManager.GetAllSlides())
            {
                parameters.Slider.Add(new ImageInfo
                {
                    imageName = sliderPhotoManager.GetName(it.CarPhotoId),
                    description = it.Car.MainData.Model.Brand.Name + " " + it.Car.MainData.Model.Name
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