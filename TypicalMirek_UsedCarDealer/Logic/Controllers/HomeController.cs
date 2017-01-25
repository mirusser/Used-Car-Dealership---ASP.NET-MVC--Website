using System.Collections.Generic;
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
        private readonly IBrandManager brandManager;
        private readonly ISourceOfEnergyRepository sourceOfEnergyRepository;
        private readonly IWebsiteContextManager websiteContextManager;
        private readonly IMarkersConfigurationManager markersConfigurationManager;

        public HomeController(IManagerFactory managerFactory)
        {
            sliderPhotoManager = managerFactory.Get<SliderPhotoManager>();
            carManager = managerFactory.Get<CarManager>();
            brandManager = managerFactory.Get<BrandManager>();
            sourceOfEnergyRepository = new SourceOfEnergyRepository();
            websiteContextManager = managerFactory.Get<WebsiteContextManager>();
            markersConfigurationManager = managerFactory.Get<MarkersConfigurationManager>();
        }

        public ActionResult Index()
        {
            var parameters = new ParametersToHome
            {
                Slider = new List<CarPhotoViewModel>(),
                HotCars = new List<CarPhotoViewModel>(),
                NewCars = new List<CarPhotoViewModel>()
            };

            parameters.Slider = sliderPhotoManager.GetAllAsCarPhotoViewModel();

            var hotCars = carManager.GetAllCars().Where(it => it.Photos.Count > 0 && it.DeleteTime == null).OrderByDescending(it => it.NumberOfViews).Take(8);

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

            parameters.BrandList = brandManager.GetAll().Select(it => it.Name);

            parameters.FuelTypeList = sourceOfEnergyRepository.GetAll().Select(it => it.Name);

            return View(parameters);
        }

        #region About
        public ActionResult About(string result = null)
        {
            var parameters = new ParametersToAbout
            {
                MapLocalization = markersConfigurationManager.GetMapLocalization(),
                Markerslocalizations = markersConfigurationManager.GetAllMarkers(),
                PageContent = websiteContextManager.GetContextByName("About")?.Context
            };

            return View(parameters);
        }
        #endregion

        #region Contact
        public ActionResult Contact(string result = null)
        {
            var context = websiteContextManager.GetContextByName("Contact");
            string content = null;
            if (context != null)
            {
                content = context.Context;
            }

            var parametersToContact = new ParametersToContact
            {
                Result = result,
                Content = content
            };
            return View(parametersToContact);
        }
        #endregion
    }
}