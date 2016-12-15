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
using TypicalMirek_UsedCarDealer.Models.UnitOfWork;
using TypicalMirek_UsedCarDealer.Models.ViewModels;
using static TypicalMirek_UsedCarDealer.Logic.Helpers.SelectListItemHelper;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class CarManager : Manager, ICarManager
    {
        private readonly UnitOfWork unitOfWork;
        #region Repositories
        //private readonly ICarRepository carRepository;
        //private readonly ITypeRepository typeRepository;
        //private readonly ICharacterRepository characterRepository;
        //private readonly IBrandRepository brandRepository;
        //private readonly IBodyRepository bodyRepository;
        //private readonly IPropulsionRepository propulsionRepository;
        //private readonly ISourceOfEnergyRepository sourceOfEnergyRepository;
        //private readonly IModelRepository modelRepository;

        //private readonly IMainDataRepository mainDataRepository;
        //private readonly IAdditionalDataRepository additionalDataRepository;
        //private readonly IAdditionalEquipmentRepository additionalEquipmentRepository;
        //private readonly ICarPhotoRepository carPhotoRepository;

        //private readonly IColorRepository colorRepository;
        //private readonly IGearboxRepository gearboxRepository;
        //private readonly ICountryRepository countryRepository;
        //private readonly IPositionOfSteeringWheelRepository positionOfSteeringWheelRepository;
        #endregion

        #region Constructors
        public CarManager() { }

        public CarManager(IRepositoryFactory repositoryFactory)
        {
            unitOfWork = new UnitOfWork(repositoryFactory);
            //carRepository = repositoryFactory.Get<CarRepository>();
            //typeRepository = repositoryFactory.Get<TypeRepository>();
            //characterRepository = repositoryFactory.Get<CharacterRepository>();
            //brandRepository = repositoryFactory.Get<BrandRepository>();
            //bodyRepository = repositoryFactory.Get<BodyRepository>();
            //propulsionRepository = repositoryFactory.Get<PropulsionRepository>();
            //sourceOfEnergyRepository = repositoryFactory.Get<SourceOfEnergyRepository>();
            //modelRepository = repositoryFactory.Get<ModelRepository>();

            //mainDataRepository = repositoryFactory.Get<MainDataRepository>();
            //additionalEquipmentRepository = repositoryFactory.Get<AdditionalEquipmentRepository>();
            //additionalDataRepository = repositoryFactory.Get<AdditionalDataRepository>();
            //carPhotoRepository = repositoryFactory.Get<CarPhotoRepository>();

            //colorRepository = repositoryFactory.Get<ColorRepository>();
            //gearboxRepository = repositoryFactory.Get<GearboxRepository>();
            //countryRepository = repositoryFactory.Get<CountryRepository>();
            //positionOfSteeringWheelRepository = repositoryFactory.Get<PositionOfSteeringWheelRepository>();
        }
        #endregion

        public AddCarViewModel CreateAddCarViewModel()
        {
            return new AddCarViewModel
            {
                Types = GetSelectListItem(unitOfWork.TypeRepository),
                Characters = GetSelectListItem(unitOfWork.CharacterRepository),
                Brands = GetSelectListItem(unitOfWork.BrandRepository),
                Bodies = GetSelectListItem(unitOfWork.BodyRepository),
                Propulsions = GetSelectListItem(unitOfWork.PropulsionRepository),
                SourcesOfEnergy = GetSelectListItem(unitOfWork.SourceOfEnergyRepository),
                Models = GetSelectListItem(unitOfWork.ModelRepository),
                Colors = GetSelectListItem(unitOfWork.ColorRepository),
                Gearboxes = GetSelectListItem(unitOfWork.GearboxRepository),
                Countries = GetSelectListItem(unitOfWork.CountryRepository),
                PositionsOfSteeringWheel = GetSelectListItem(unitOfWork.PositionOfSteeringWheelRepository)
            };
        }

        public AddCarViewModel Add(AddCarViewModel car)
        {
            var carToAdd = MappingHelper.MappAddingCarViewModelToCarModel(car);

            unitOfWork.CarRepository.Add(carToAdd);
            unitOfWork.Save();

            return null;
        }

        public AddCarViewModel Modify(AddCarViewModel car)
        {
            var carToModify = unitOfWork.CarRepository.GetById(car.Id);
            MappingHelper.MappAddingCarViewModelToExistingCarModel(car, carToModify);

            //carRepository.Update(carToModify);
            unitOfWork.Save();

            return null;
        }

        public void RemoveCarById(int id)
        {
            var car = unitOfWork.CarRepository.GetById(id);

            if (car.AdditionalData != null)
            {
                if (car.AdditionalData.AdditionalEquipment != null)
                {
                    unitOfWork.AdditionalEquipmentRepository.Delete(car.AdditionalData.AdditionalEquipment.Id);
                    car.AdditionalData.AdditionalEquipmentId = null;
                    unitOfWork.AdditionalEquipmentRepository.Save();
                }
                unitOfWork.AdditionalDataRepository.Delete(car.AdditionalData.Id);
                car.AdditionalDataId = null;
                unitOfWork.AdditionalDataRepository.Save();
            }

            unitOfWork.MainDataRepository.Delete(car.MainData.Id);
            foreach (var carphoto in car.Photos)
            {
                unitOfWork.CarPhotoRepository.Delete(carphoto.Id);
            }
            unitOfWork.CarPhotoRepository.Save();

            unitOfWork.CarRepository.Delete(car);
            unitOfWork.Save();
        }

        public Car GetCarById(int id)
        {
            return unitOfWork.CarRepository.GetById(id);
        }

        public AddCarViewModel GetAddCarViewModel(int id)
        {
            var car = MappingHelper.MappCarModelToAddingCarViewModel(GetCarById(id));
            car.Types = GetSelectListItem(unitOfWork.TypeRepository);
            car.Characters = GetSelectListItem(unitOfWork.CharacterRepository);
            car.Brands = GetSelectListItem(unitOfWork.BrandRepository);
            car.Bodies = GetSelectListItem(unitOfWork.BodyRepository);
            car.Propulsions = GetSelectListItem(unitOfWork.PropulsionRepository);
            car.SourcesOfEnergy = GetSelectListItem(unitOfWork.SourceOfEnergyRepository);
            car.Models = GetSelectListItem(unitOfWork.ModelRepository);
            car.Colors = GetSelectListItem(unitOfWork.ColorRepository);
            car.Gearboxes = GetSelectListItem(unitOfWork.GearboxRepository);
            car.Countries = GetSelectListItem(unitOfWork.CountryRepository);
            car.PositionsOfSteeringWheel = GetSelectListItem(unitOfWork.PositionOfSteeringWheelRepository);
            return car;
        }

        public CarDetailsViewModel GetCarDetailsViewModelById(int id)
        {
            return MappingHelper.MappCarModelToCarDetailsViewModel(unitOfWork.CarRepository.GetById(id));
        }

        public IQueryable<Car> GetAllCars()
        {
            return unitOfWork.CarRepository.GetAll();
        }

        public IList<DisplayCarViewModel> GetAllCarsToDisplay()
        {
            return MappingHelper.MapCarsToListOfCarsToDisplay(unitOfWork.CarRepository.GetAll());
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}