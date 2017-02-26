﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderPhotoManager sliderPhotoManager;
        private readonly ICarManager carManager;

        public SliderController(IManagerFactory managerFactory)
        {
            sliderPhotoManager = managerFactory.Get<SliderPhotoManager>();
            carManager = managerFactory.Get<CarManager>();
        }

        public ActionResult AddPhotosToSlider()
        {
            var idsCarInSlider = sliderPhotoManager.GetAllSlides().Select(it => it.CarId).ToArray();

            var cars = carManager.GetCarsForAddToSlider(idsCarInSlider);

            var parameters = cars.Select(it => new CarToSlider
            {
                CarId = it.Id,
                CarName = it.Id + " " + it.MainData.Model.Brand.Name + " " + it.MainData.Model.Name
            });

            return View(parameters);
        }

        public ActionResult DeletePhotosFromSlider()
        {
            var cars = sliderPhotoManager.GetAllAsCarPhotoViewModel();
            return View(cars);
        }
    }
}