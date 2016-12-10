using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Helpers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.ViewModels;
using static TypicalMirek_UsedCarDealer.Logic.Helpers.SelectListItemHelper;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class CarManager : Manager, ICarManager
    {
        #region Repositories
        private readonly ICarRepository carRepository;
        private readonly ITypeRepository typeRepository;
        private readonly ICharacterRepository characterRepository;
        private readonly IBrandRepository brandRepository;
        private readonly IBodyRepository bodyRepository;
        private readonly IPropulsionRepository propulsionRepository;
        private readonly ISourceOfEnergyRepository sourceOfEnergyRepository;
        private readonly IModelRepository modelRepository;

        private readonly IMainDataRepository mainDataRepository;
        private readonly IAdditionalDataRepository additionalDataRepository;
        private readonly IAdditionalEquipmentRepository additionalEquipmentRepository;
        private readonly ICarPhotoRepository carPhotoRepository;

        private readonly IColorRepository colorRepository;
        private readonly IGearboxRepository gearboxRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IPositionOfSteeringWheelRepository positionOfSteeringWheelRepository;
        #endregion

        #region Constructors
        public CarManager() { }

        public CarManager(IRepositoryFactory repositoryFactory)
        {
            carRepository = repositoryFactory.Get<CarRepository>();
            typeRepository = repositoryFactory.Get<TypeRepository>();
            characterRepository = repositoryFactory.Get<CharacterRepository>();
            brandRepository = repositoryFactory.Get<BrandRepository>();
            bodyRepository = repositoryFactory.Get<BodyRepository>();
            propulsionRepository = repositoryFactory.Get<PropulsionRepository>();
            sourceOfEnergyRepository = repositoryFactory.Get<SourceOfEnergyRepository>();
            modelRepository = repositoryFactory.Get<ModelRepository>();

            mainDataRepository = repositoryFactory.Get<MainDataRepository>();
            additionalEquipmentRepository = repositoryFactory.Get<AdditionalEquipmentRepository>();
            additionalDataRepository = repositoryFactory.Get<AdditionalDataRepository>();
            carPhotoRepository = repositoryFactory.Get<CarPhotoRepository>();

            colorRepository = repositoryFactory.Get<ColorRepository>();
            gearboxRepository = repositoryFactory.Get<GearboxRepository>();
            countryRepository = repositoryFactory.Get<CountryRepository>();
            positionOfSteeringWheelRepository = repositoryFactory.Get<PositionOfSteeringWheelRepository>();
        }
        #endregion

        public AddCarViewModel CreateAddCarViewModel()
        {
            return new AddCarViewModel
            {
                Types = GetSelectListItem(typeRepository),
                Characters = GetSelectListItem(characterRepository),
                Brands = GetSelectListItem(brandRepository),
                Bodies = GetSelectListItem(bodyRepository),
                Propulsions = GetSelectListItem(propulsionRepository),
                SourcesOfEnergy = GetSelectListItem(sourceOfEnergyRepository),
                Models = GetSelectListItem(modelRepository),
                Colors = GetSelectListItem(colorRepository),
                Gearboxes = GetSelectListItem(gearboxRepository),
                Countries = GetSelectListItem(countryRepository),
                PositionsOfSteeringWheel = GetSelectListItem(positionOfSteeringWheelRepository)
            };
        }

        public AddCarViewModel Add(AddCarViewModel car)
        {
            var carToAdd = MappingHelper.MappAddingCarViewModelToCarModel(car);

            carRepository.Add(carToAdd);
            carRepository.Save();

            return null;
        }

        public AddCarViewModel Modify(AddCarViewModel car)
        {
            var carToModify = carRepository.GetById(car.Id);
            MappingHelper.MappAddingCarViewModelToExistingCarModel(car, carToModify);

            carRepository.Save();

            return null;
        }

        public void RemoveCarById(int id)
        {
            var car = carRepository.GetById(id);

            if (car.AdditionalData != null)
            {
                if (car.AdditionalData.AdditionalEquipment != null)
                {
                    additionalEquipmentRepository.Delete(car.AdditionalData.AdditionalEquipment);
                    car.AdditionalData.AdditionalEquipmentId = null;
                    car.AdditionalData.AdditionalEquipment = null;
                    additionalDataRepository.Save();
                    additionalEquipmentRepository.Save();
                }

                additionalDataRepository.Delete(car.AdditionalData);
                car.AdditionalDataId = null;
                additionalDataRepository.Save();
            }

            mainDataRepository.Delete(car.MainData.Id);
            foreach (var carphoto in car.Photos)
            {
                carPhotoRepository.Delete(carphoto.Id);
            }
            carPhotoRepository.Save();

            carRepository.Delete(car);
            carRepository.Save();
        }

        public Car GetCarById(int id)
        {
            return carRepository.GetById(id);
        }

        public AddCarViewModel GetAddCarViewModel(int id)
        {
            var car = MappingHelper.MappCarModelToAddingCarViewModel(GetCarById(id));
            car.Types = GetSelectListItem(typeRepository);
            car.Characters = GetSelectListItem(characterRepository);
            car.Brands = GetSelectListItem(brandRepository);
            car.Bodies = GetSelectListItem(bodyRepository);
            car.Propulsions = GetSelectListItem(propulsionRepository);
            car.SourcesOfEnergy = GetSelectListItem(sourceOfEnergyRepository);
            car.Models = GetSelectListItem(modelRepository);
            car.Colors = GetSelectListItem(colorRepository);
            car.Gearboxes = GetSelectListItem(gearboxRepository);
            car.Countries = GetSelectListItem(countryRepository);
            car.PositionsOfSteeringWheel = GetSelectListItem(positionOfSteeringWheelRepository);
            return car;
        }

        public CarDetailsViewModel GetCarDetailsViewModelById(int id)
        {
            return MappingHelper.MappCarModelToCarDetailsViewModel(carRepository.GetById(id));
        }

        public IQueryable<Car> GetAllCars()
        {
            return carRepository.GetAll();
        }

        public IList<DisplayCarViewModel> GetAllCarsToDisplay()
        {
            return MappingHelper.MapCarsToListOfCarsToDisplay(carRepository.GetAll());
        }

        public void Dispose()
        {
            carRepository.Dispose();
        }
    }
}