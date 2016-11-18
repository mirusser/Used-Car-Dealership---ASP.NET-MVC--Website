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
        public static Car MappAddingCarViewModelToExistingCarModel(AddCarViewModel addCarViewModel, Car car)
        {
            car.BodyId = addCarViewModel.BodyId;
            car.PropulsionId = addCarViewModel.PropulsionId;
            car.SourceOfEnergyId = addCarViewModel.SourceOfEnergyId;
            if (car.Photos == null)
            {
                car.Photos = new List<CarPhoto>();
            }

            car.MainData.TypeId = addCarViewModel.TypeId;
            car.MainData.CharacterId = addCarViewModel.CharacterId;

            car.MainData.Model.Name = addCarViewModel.ModelName;
            car.MainData.Model.BrandId = addCarViewModel.BrandId;
            car.MainData.Model.Version = addCarViewModel.ModelVersion;

            if (car.AdditionalData == null)
            {
                car.AdditionalData = new AdditionalData
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
                };
            }
            else
            {
                car.AdditionalData.NumberOfSeats = addCarViewModel.NumberOfSeats;
                car.AdditionalData.EngineCapacity = addCarViewModel.EngineCapacity;
                car.AdditionalData.Damaged = addCarViewModel.Damaged;
                car.AdditionalData.Mass = addCarViewModel.Mass;
                car.AdditionalData.EnginePower = addCarViewModel.EnginePower;
                car.AdditionalData.Length = addCarViewModel.Length;
                car.AdditionalData.NumberOfOwners = addCarViewModel.NumberOfOwners;
                car.AdditionalData.Milleage = addCarViewModel.Milleage;
                car.AdditionalData.FuelTankCapacity = addCarViewModel.FuelTankCapacity;
                car.AdditionalData.YearOfProduction = Convert.ToInt32(addCarViewModel.YearOfProduction);
                car.AdditionalData.ColorId = addCarViewModel.ColorId;
                car.AdditionalData.CountryId = addCarViewModel.CountryId;
                car.AdditionalData.GearboxId = addCarViewModel.GearboxId;
                car.AdditionalData.PositionOfSteeringWheelId = addCarViewModel.PositionOfSteeringWheelId;
                if (car.AdditionalData.AdditionalEquipment == null)
                {
                    car.AdditionalData.AdditionalEquipment = new AdditionalEquipment
                    {
                        AdditionalWheels = addCarViewModel.AdditionalWheels,
                        Climatisation = addCarViewModel.Climatisation,
                        Radio = addCarViewModel.Radio,
                        Towbar = addCarViewModel.Towbar
                    };
                }
                else
                {
                    car.AdditionalData.AdditionalEquipment.AdditionalWheels = addCarViewModel.AdditionalWheels;
                    car.AdditionalData.AdditionalEquipment.Climatisation = addCarViewModel.Climatisation;
                    car.AdditionalData.AdditionalEquipment.Radio = addCarViewModel.Radio;
                    car.AdditionalData.AdditionalEquipment.Towbar = addCarViewModel.Towbar;
                }
            }

            foreach (var file in addCarViewModel.Files)
            {
                if (file != null)
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
            }
            return car;
        }

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

            if (addCarViewModel.Files != null)
            {
                foreach (var file in addCarViewModel.Files)
                {
                    if (file != null)
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

                Id = car.Id,
                EngineCapacity = car.AdditionalData?.EngineCapacity,
                Damaged = car.AdditionalData?.Damaged ?? false,
                NumberOfSeats = car.AdditionalData?.NumberOfSeats,
                AdditionalWheels = car.AdditionalData?.AdditionalEquipment?.AdditionalWheels ?? false,
                Climatisation = car.AdditionalData?.AdditionalEquipment?.Climatisation ?? false,
                ColorId = car.AdditionalData?.Color?.Id,
                CountryId = car.AdditionalData?.Country?.Id,
                EnginePower = car.AdditionalData?.EnginePower,
                FuelTankCapacity = car.AdditionalData?.FuelTankCapacity,
                GearboxId = car.AdditionalData?.GearBox?.Id,
                Length = car.AdditionalData?.Length,
                Mass = car.AdditionalData?.Mass,
                Milleage = car.AdditionalData?.Milleage,
                ModelName = car.MainData.Model.Name,
                ModelVersion = car.MainData.Model.Version,
                NumberOfOwners = car.AdditionalData?.NumberOfOwners,
                PositionOfSteeringWheelId = car.AdditionalData?.PositionOfSteeringWheel?.Id,
                Radio = car.AdditionalData?.AdditionalEquipment?.Radio ?? false,
                Towbar = car.AdditionalData?.AdditionalEquipment?.Towbar ?? false,
                YearOfProduction = car.AdditionalData?.YearOfProduction,
                Photos = car.Photos
            };
        }

        //TODO refactor this method
        public static IList<DisplayCarViewModel> MapCarsToListOfCarsToDisplay(/*ICarRepository carRepository*/IQueryable<Car> cars )
        {
            var listOfCarsToDisplay = new List<DisplayCarViewModel>();

            cars.ForEach(x =>
            {
                listOfCarsToDisplay.Add(MappCarModelToDisplayCarViewModel(x));
            });

            return listOfCarsToDisplay;
        }

        public static DisplayCarViewModel MappCarModelToDisplayCarViewModel(Car car)
        {
            var firstOrDefault = car.Photos?.FirstOrDefault();
            if (firstOrDefault != null)
            {
                return new DisplayCarViewModel(car.MainData.Model)
                {
                    Id = car.Id,
                    CarImagePath = firstOrDefault.ImagePath ?? null,
                    CarImageName = firstOrDefault.Name
                };
            }
            else
            {
                try
                {
                    if (car.MainData.Model?.Brand == null)
                    {

                    }
                }
                catch (Exception ex)
                {
                    
                    throw;
                }
                

                return new DisplayCarViewModel(car.MainData.Model)
                {
                    Id = car.Id,
                    CarImagePath = null
                };
            }
        }

        public static CarDetailsViewModel MappCarModelToCarDetailsViewModel(Car car)
        {
            return new CarDetailsViewModel
            {
                Id = car.Id,
                Type = car.MainData.Type.Name,
                EngineCapacity = car.AdditionalData?.EngineCapacity,
                Damaged = car.AdditionalData?.Damaged,
                NumberOfSeats = car.AdditionalData?.NumberOfSeats,
                AdditionalWheels = car.AdditionalData?.AdditionalEquipment?.AdditionalWheels,
                Body = car.Body.Name,
                Brand = car.MainData.Model.Brand.Name,
                Character = car.MainData.Character.Name,
                Climatisation = car.AdditionalData?.AdditionalEquipment?.Climatisation,
                Color = car.AdditionalData?.Color?.Name,
                Country = car.AdditionalData?.Country?.Name,
                EnginePower = car.AdditionalData?.EnginePower,
                FuelTankCapacity = car.AdditionalData?.FuelTankCapacity,
                Gearbox = car.AdditionalData?.GearBox?.Name,
                Length = car.AdditionalData?.Length,
                Mass = car.AdditionalData?.Mass,
                Milleage = car.AdditionalData?.Milleage,
                ModelName = car.MainData.Model.Name,
                ModelVersion = car.MainData.Model.Version,
                NumberOfOwners = car.AdditionalData?.NumberOfOwners,
                PositionOfSteeringWheel = car.AdditionalData?.PositionOfSteeringWheel?.Name,
                Propulsion = car.Propulsion.Name,
                Radio = car.AdditionalData?.AdditionalEquipment?.Radio,
                SourceOfEnergy = car.SourceOfEnergy.Name,
                Towbar = car.AdditionalData?.AdditionalEquipment?.Towbar,
                YearOfProduction = car.AdditionalData?.YearOfProduction,
                Photos = car.Photos
            };
        }
    }
}