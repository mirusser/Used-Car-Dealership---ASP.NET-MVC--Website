using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class CarManagementController : Controller
    {
        #region Properties
        private readonly ICarManager carManager;
        private readonly ISliderPhotoManager sliderPhotoManager;
        #endregion

        #region Constructors
        public CarManagementController(IManagerFactory managerFactory)
        {
            carManager = managerFactory.Get<CarManager>();
            sliderPhotoManager = managerFactory.Get<SliderPhotoManager>();
        }
        #endregion

        [Authorize(Roles = "Admin")]
        public ActionResult List()
        {
            var cars = carManager.GetAllCarsToDisplay();
            return View(cars.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var car = carManager.GetCarDetailsViewModelById(Convert.ToInt32(id));
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var carToAdd = carManager.CreateAddCarViewModel();
            return View(carToAdd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(AddCarViewModel car)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    saveFileOnServer(car.Files);
                    carManager.Add(car);
                    return RedirectToAction("List");
                }
                catch (Exception ex)
                {
                    car = carManager.SetCarSelecLists(car);
                    return View(car);
                }
            }

            car = carManager.SetCarSelecLists(car);
            return View(car);
        }

        [Authorize(Roles = "Admin")]
        private void saveFileOnServer(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file?.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        if (fileName != null)
                        {
                            var path = Path.Combine(Server.MapPath("~/App_Data/Images"), fileName);
                            file.SaveAs(path);
                        }
                    }
                }
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var car = carManager.GetAddCarViewModel(Convert.ToInt32(id));
            if (car == null)
            {
                return HttpNotFound();
            }

            car = carManager.SetCarSelecLists(car);
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(AddCarViewModel car)
        {
            if (ModelState.IsValid)
            {
                carManager.Modify(car);
                return RedirectToAction("List");
            }

            car = carManager.SetCarSelecLists(car);
            return View(car);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var car = carManager.GetCarById(Convert.ToInt32(id));
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            var carPhotos = carManager.GetAllCarPhotos(id);
            carPhotos.ForEach(p =>
            {
                var imagePath = getImagePath(p.Name);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            });

            carManager.RemoveCarById(id);
            return RedirectToAction("List");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Suspend(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var car = carManager.GetCarById(Convert.ToInt32(id));
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        [HttpPost, ActionName("Suspend")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult SuspendConfirmed(int id)
        {
            if (carManager.SuspendCarById(id))
            {
                sliderPhotoManager.DeleteByCarId(id);
                return RedirectToAction("List");
            }
            return HttpNotFound();
        }

        [Authorize(Roles = "Admin")]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                carManager.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GetCarImage(string imageName)
        {
            var path = getImagePath(imageName);
            return File(path, "image/jpeg/png/PNG/jpg");
        }

        private string getImagePath(string imageName)
        {
            if (string.IsNullOrEmpty(imageName))
            {
                imageName = "empty";
            }
            var path = Path.Combine(Server.MapPath("~/App_Data/Images"), imageName);
            return Path.GetFullPath(path);
        }
    }
}
