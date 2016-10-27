using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.ViewModels;
using WebGrease.Css.Extensions;

namespace TypicalMirek_UsedCarDealer.Logic.Helpers
{
    public static class MappingHelper
    {
        public static Car MappAddingCarViewModelToCarModel(AddCarViewModel addCarViewModel)
        {
            //TODO fill another properties of Car class
            return new Car
            {
                MainData = new MainData
                {
                    TypeId = addCarViewModel.TypeId,
                    CharacterId = addCarViewModel.CharacterId,
                    ModelId = addCarViewModel.ModelId
                },
                BodyId = addCarViewModel.BodyId,
                PropulsionId = addCarViewModel.PropulsionId,
                SourceOfEnergyId = addCarViewModel.SourceOfEnergyId,
                
            };
        }

        //TODO add another properties
        public static AddCarViewModel MappCarModelToAddingCarViewModel(Car car)
        {
            return new AddCarViewModel
            {
                TypeId = car.MainData.TypeId,
                CharacterId = car.MainData.CharacterId,
                BrandId = car.MainData.Model.BrandId,
                ModelId = car.MainData.ModelId,
                BodyId = car.BodyId,
                PropulsionId = car.PropulsionId,
                SourceOfEnergyId = car.SourceOfEnergyId,
            };
        }

        //TODO refactor this method
        public static IList<DisplayCarViewModel> MapCarsToListOfCarsToDisplay(ICarRepository carRepository)
        {
            var listOfCarsToDisplay = new List<DisplayCarViewModel>();

            carRepository.GetAll().ForEach(x =>
            {
                listOfCarsToDisplay.Add(MappCarModelToDisplayCarViewModel(x));
            });

            return listOfCarsToDisplay;
        }

        public static DisplayCarViewModel MappCarModelToDisplayCarViewModel(Car car)
        {
            Image carImage;

            if (car.Photos.FirstOrDefault() != null)
            {
                using (var memoryStream = new MemoryStream(car.Photos.FirstOrDefault()?.Image))
                {
                    carImage = Image.FromStream(memoryStream);
                }
            }
            else
            {
                carImage = null;
            }

            return new DisplayCarViewModel(car.MainData.Model)
            {
                Id = car.Id,
                CarImage = carImage
            };
        }
    }
}