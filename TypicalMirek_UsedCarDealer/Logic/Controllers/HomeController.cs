using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderPhotoManager sliderPhotoManager;

        public HomeController(IManagerFactory managerFactory)
        {
            sliderPhotoManager = managerFactory.Get<SliderPhotoManager>();
        }

        public ActionResult Index()
        {
            return View(sliderPhotoManager.GetNames());
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