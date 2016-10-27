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
                Models = GetSelectListItem(modelRepository)
            };
        }

        public AddCarViewModel Add(AddCarViewModel car)
        {
            var carToAdd = MappingHelper.MappAddingCarViewModelToCarModel(car);

            carRepository.Add(carToAdd);
            carRepository.Save();

            return null;
        }

        public Car GetCarById(int id)
        {
            return carRepository.GetById(id);
        }

        public IQueryable<Car> GetAllCars()
        {
            return carRepository.GetAll();
        }

        public IList<DisplayCarViewModel> GetAllCarsToDisplay()
        {
            return MappingHelper.MapCarsToListOfCarsToDisplay(carRepository);
        }

        public void Dispose()
        {
            carRepository.Dispose();
        }
    }
}