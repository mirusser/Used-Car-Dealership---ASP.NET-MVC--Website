using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Factories;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class CarManager : Manager, ICarManager
    {
        #region Repositories
        private ICarRepository carRepository;
        private readonly ITypeRepository typeRepository;
        private readonly ICharacterRepository characterRepository;
        private readonly IBrandRepository brandRepository;
        private readonly IBodyRepository bodyRepository;
        private readonly IPropulsionRepository propulsionRepository;
        private readonly ISourceOfEnergyRepository sourceOfEnergyRepository;
        #endregion

        #region Constructors
        public CarManager() { }

        public CarManager(RepositoryFactory repositoryFactory)
        {
            carRepository = repositoryFactory.Get<CarRepository>();
            typeRepository = repositoryFactory.Get<TypeRepository>();
            characterRepository = repositoryFactory.Get<CharacterRepository>();
            brandRepository = repositoryFactory.Get<BrandRepository>();
            bodyRepository = repositoryFactory.Get<BodyRepository>();
            propulsionRepository = repositoryFactory.Get<PropulsionRepository>();
            sourceOfEnergyRepository = repositoryFactory.Get<SourceOfEnergyRepository>();
        }
        #endregion


        public AddCarViewModel CreateAddCarViewModel()
        {
            var types = typeRepository.GetAll();
            var characters = characterRepository.GetAll();
            var brands = brandRepository.GetAll();
            var bodies = bodyRepository.GetAll();
            var propulsions = propulsionRepository.GetAll();
            var sourcesOfEnergy = sourceOfEnergyRepository.GetAll();

            return new AddCarViewModel
            {

            };
        }
    }
}