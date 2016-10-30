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
            var car = new Car
            {
                BodyId = addCarViewModel.BodyId,
                PropulsionId = addCarViewModel.PropulsionId,
                SourceOfEnergyId = addCarViewModel.SourceOfEnergyId,
                Photos = new List<CarPhoto>(),
                MainData = new MainData
                {
                    TypeId = addCarViewModel.TypeId,
                    CharacterId = addCarViewModel.CharacterId,
                    Model = new Model
                    {
                        Name = addCarViewModel.ModelName,
                        BrandId = addCarViewModel.BrandId,
                        Version = addCarViewModel.ModelVersion
                    }
                },
                AdditionalData = new AdditionalData
                {
                    NumberOfSeats = addCarViewModel.NumberOfSeats,
                    EngineCapacity = addCarViewModel.EngineCapacity,
                    Damaged = addCarViewModel.Damaged,
                    Mass = addCarViewModel.Mass,
                    EnginePower = addCarViewModel.EnginePower,
                    Length = addCarViewModel.Length,
                    NumberOfOwners = addCarViewModel.NumberOfOwners,
                    Milleage = addCarViewModel.Milleage,
                    FuelTankCapacity = addCarViewModel.FuelTankCapacity,
                    YearOfProduction = Convert.ToInt32(addCarViewModel.YearOfProduction),
                    ColorId = addCarViewModel.ColorId,
                    CountryId = addCarViewModel.CountryId,
                    GearboxId = addCarViewModel.GearboxId,
                    PositionOfSteeringWheelId = addCarViewModel.PositionOfSteeringWheelId,
                    AdditionalEquipment = new AdditionalEquipment
                    {
                        AdditionalWheels = addCarViewModel.AdditionalWheels,
                        Climatisation = addCarViewModel.Climatisation,
                        Radio = addCarViewModel.Radio,
                        Towbar = addCarViewModel.Towbar
                    },
                },
            };

            foreach (var file in addCarViewModel.Files)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.InputStream.CopyTo(memoryStream);
                    car.Photos.Add(new CarPhoto
                    {
                        Image = memoryStream.GetBuffer(),
                        //Name = Path.GetFileNameWithoutExtension(file.FileName),
                        Name = file.FileName,
                        CarId = car.Id,
                        ImagePath = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Images\\" + file.FileName,
                    });
                }
            }
            return car;
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
            var firstOrDefault = car.Photos.FirstOrDefault();
            if (firstOrDefault != null)
            {
                return new DisplayCarViewModel(car.MainData.Model)
                {
                    Id = car.Id,
                    CarImagePath = firstOrDefault.ImagePath,
                    CarImageName = firstOrDefault.Name
                };
            }
            else
            {
                return new DisplayCarViewModel(car.MainData.Model)
                {
                    Id = car.Id,
                    CarImagePath = null
                };
            }
        }
    }
}