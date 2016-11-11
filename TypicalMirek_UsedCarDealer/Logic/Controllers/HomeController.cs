using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderPhotoRepository sliderPhotoRepository;
        private readonly ICarPhotoRepository carPhotoRepository;

        public HomeController(IRepositoryFactory repositoryFactory)
        {
            sliderPhotoRepository = repositoryFactory.Get<SliderPhotoRepository>();
            carPhotoRepository = repositoryFactory.Get<CarPhotoRepository>();
        }

        public ActionResult Index()
        {
            var sliderPhotoNames = new List<string>();
            var sliderPhotos = sliderPhotoRepository.GetAll().ToList();
            sliderPhotos.ForEach(p =>
            {
                sliderPhotoNames.Add(carPhotoRepository.GetById(p.Id).Name);
            });

            return View(sliderPhotoNames);
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