using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class SliderController : Controller
    {
        private readonly ISliderPhotoManager sliderPhotoManager;
        private readonly ICarManager carManager;

        public SliderController(IManagerFactory managerFactory)
        {
            sliderPhotoManager = managerFactory.Get<SliderPhotoManager>();
            carManager = managerFactory.Get<CarManager>();
        }

        //public ActionResult SelectCar()
        //{
        //    var sliderPhotos = sliderPhotoManager.GetAllAsCarPhotoViewModel();

        //    IList<Car> cars = carManager.GetAllCars().ToList();

        //    foreach (var it in sliderPhotos)
        //    {
        //        cars.Remove();
        //    }

        //    return View(cars);
        //}        //public ActionResult SelectCar()
        //{
        //    var sliderPhotos = sliderPhotoManager.GetAllAsCarPhotoViewModel();

        //    IList<Car> cars = carManager.GetAllCars().ToList();

        //    foreach (var it in sliderPhotos)
        //    {
        //        cars.Remove();
        //    }

        //    return View(cars);
        //}

        [HttpPost]
        public ActionResult SelectPhotosForCars(string CarIds)
        {
            //var parameters = new ParametersToSlider
            //{
            //    SliderPhotos = sliderPhotoManager.GetAllAsCarPhotoViewModel(),
            //    CarsPhotos = new List<CarPhotos>()
            //};

            //foreach (var it in carManager.GetAllCars())
            //{
            //    parameters.CarsPhotos.Add(new CarPhotos
            //    {
            //        CarId = it.Id,
            //        CarName = it.MainData.Model.Brand.Name + " " + it.MainData.Model.Name,
            //        Photos = it.Photos
            //    });
            //}
            return View();
        }

        public ActionResult SliderImages()
        {
            return View(sliderPhotoManager.GetAllAsCarPhotoViewModel());
        }
    }
}