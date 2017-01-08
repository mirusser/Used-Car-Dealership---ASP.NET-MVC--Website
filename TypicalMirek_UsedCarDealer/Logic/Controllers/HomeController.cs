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
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderPhotoManager sliderPhotoManager;
        private readonly ICarManager carManager;
        private readonly IBrandManager brandManager;
        private readonly ISourceOfEnergyRepository sourceOfEnergyRepository;
        private readonly IWebsiteContextManager websiteContextManager;

        public HomeController(IManagerFactory managerFactory)
        {
            sliderPhotoManager = managerFactory.Get<SliderPhotoManager>();
            carManager = managerFactory.Get<CarManager>();
            brandManager = managerFactory.Get<BrandManager>();
            sourceOfEnergyRepository = new SourceOfEnergyRepository();
            websiteContextManager = managerFactory.Get<WebsiteContextManager>();
        }

        public ActionResult Index()
        {
            var parameters = new ParametersToHome
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
            var context = websiteContextManager.GetContextByName("Contact");

            return View(model: context?.Context);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditAbout()
        {
            var context = websiteContextManager.GetContextByName("About");

            var parameters = new ParametersToWysiwyg
            {
                Context = context?.Context,
                SiteName = "About"
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
        
        [Authorize(Roles = "Admin")]
        public ActionResult EditContact()
        {
            var context = websiteContextManager.GetContextByName("Contact");

            var parameters = new ParametersToWysiwyg
            {
                Context = context?.Context,
                SiteName = "Contact"
            };

            return View(parameters);
        }
        #endregion

        #region Footer
        [Authorize(Roles = "Admin")]
        public ActionResult EditFooter()
        {
            var context = websiteContextManager.GetContextByName("Footer");

            var parameters = new ParametersToWysiwyg
            {
                Context = context?.Context,
                SiteName = "Footer"
            };

            return View(parameters);
        }
        #endregion
    }
}