using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Models.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly IRepositoryFactory repositoryFactory;
        private TypicalMirekEntities context { get; set; }
        private ICollection<object> initializedRepositories { get; set; }

        #region Repositories

        private IBrandRepository brandRepository;
        public IBrandRepository BrandRepository
        {
            get
            {
                if (brandRepository == null || !initializedRepositories.Contains(brandRepository))
                {
                    brandRepository = repositoryFactory.Get<BrandRepository>(context);
                    initializedRepositories.Add(brandRepository);
                }
                return brandRepository;
            }
        }

        private ICarRepository carRepository;
        public ICarRepository CarRepository
        {
            get
            {
                if (carRepository == null || !initializedRepositories.Contains(carRepository))
                {
                    carRepository = repositoryFactory.Get<CarRepository>(context);
                    initializedRepositories.Add(carRepository);
                }
                return carRepository;
            }
        }

        private ITypeRepository typeRepository;
        public ITypeRepository TypeRepository
        {
            get
            {
                if (typeRepository == null || !initializedRepositories.Contains(typeRepository))
                {
                    typeRepository = repositoryFactory.Get<TypeRepository>(context);
                    initializedRepositories.Add(typeRepository);
                }
                return typeRepository;
            }
        }

        private ICharacterRepository characterRepository;
        public ICharacterRepository CharacterRepository
        {
            get
            {
                if (characterRepository == null || !initializedRepositories.Contains(characterRepository))
                {
                    characterRepository = repositoryFactory.Get<CharacterRepository>(context);
                    initializedRepositories.Add(characterRepository);
                }
                return characterRepository;
            }
        }

        private IBodyRepository bodyRepository;
        public IBodyRepository BodyRepository
        {
            get
            {
                if (bodyRepository == null || !initializedRepositories.Contains(bodyRepository))
                {
                    bodyRepository = repositoryFactory.Get<BodyRepository>(context);
                    initializedRepositories.Add(bodyRepository);
                }
                return bodyRepository;
            }
        }

        private IPropulsionRepository propulsionRepository;
        public IPropulsionRepository PropulsionRepository
        {
            get
            {
                if (propulsionRepository == null || !initializedRepositories.Contains(propulsionRepository))
                {
                    propulsionRepository = repositoryFactory.Get<PropulsionRepository>(context);
                    initializedRepositories.Add(propulsionRepository);
                }
                return propulsionRepository;
            }
        }

        private ISourceOfEnergyRepository sourceOfEnergyRepository;
        public ISourceOfEnergyRepository SourceOfEnergyRepository
        {
            get
            {
                if (sourceOfEnergyRepository == null || !initializedRepositories.Contains(sourceOfEnergyRepository))
                {
                    sourceOfEnergyRepository = repositoryFactory.Get<SourceOfEnergyRepository>(context);
                    initializedRepositories.Add(sourceOfEnergyRepository);
                }
                return sourceOfEnergyRepository;
            }
        }

        private IModelRepository modelRepository;
        public IModelRepository ModelRepository
        {
            get
            {
                if (modelRepository == null || !initializedRepositories.Contains(modelRepository))
                {
                    modelRepository = repositoryFactory.Get<ModelRepository>(context);
                    initializedRepositories.Add(modelRepository);
                }
                return modelRepository;
            }
        }

        private IMainDataRepository mainDataRepository;
        public IMainDataRepository MainDataRepository
        {
            get
            {
                if (mainDataRepository == null || !initializedRepositories.Contains(mainDataRepository))
                {
                    mainDataRepository = repositoryFactory.Get<MainDataRepository>(context);
                    initializedRepositories.Add(mainDataRepository);
                }
                return mainDataRepository;
            }
        }

        private IAdditionalDataRepository additionalDataRepository;
        public IAdditionalDataRepository AdditionalDataRepository
        {
            get
            {
                if (additionalDataRepository == null || !initializedRepositories.Contains(additionalDataRepository))
                {
                    additionalDataRepository = repositoryFactory.Get<AdditionalDataRepository>(context);
                    initializedRepositories.Add(additionalDataRepository);
                }
                return additionalDataRepository;
            }
        }

        private IAdditionalEquipmentRepository additionalEquipmentRepository;
        public IAdditionalEquipmentRepository AdditionalEquipmentRepository
        {
            get
            {
                if (additionalEquipmentRepository == null || !initializedRepositories.Contains(additionalEquipmentRepository))
                {
                    additionalEquipmentRepository = repositoryFactory.Get<AdditionalEquipmentRepository>(context);
                    initializedRepositories.Add(additionalEquipmentRepository);
                }
                return additionalEquipmentRepository;
            }
        }

        private ICarPhotoRepository carPhotoRepository;
        public ICarPhotoRepository CarPhotoRepository
        {
            get
            {
                if (carPhotoRepository == null || !initializedRepositories.Contains(carPhotoRepository))
                {
                    carPhotoRepository = repositoryFactory.Get<CarPhotoRepository>(context);
                    initializedRepositories.Add(carPhotoRepository);
                }
                return carPhotoRepository;
            }
        }

        private IColorRepository colorRepository;
        public IColorRepository ColorRepository
        {
            get
            {
                if (colorRepository == null || !initializedRepositories.Contains(colorRepository))
                {
                    colorRepository = repositoryFactory.Get<ColorRepository>(context);
                    initializedRepositories.Add(colorRepository);
                }
                return colorRepository;
            }
        }

        private IGearboxRepository gearboxRepository;
        public IGearboxRepository GearboxRepository
        {
            get
            {
                if (gearboxRepository == null || !initializedRepositories.Contains(gearboxRepository))
                {
                    gearboxRepository = repositoryFactory.Get<GearboxRepository>(context);
                    initializedRepositories.Add(gearboxRepository);
                }
                return gearboxRepository;
            }
        }

        private ICountryRepository countryRepository;
        public ICountryRepository CountryRepository
        {
            get
            {
                if (countryRepository == null || !initializedRepositories.Contains(countryRepository))
                {
                    countryRepository = repositoryFactory.Get<CountryRepository>(context);
                    initializedRepositories.Add(countryRepository);
                }
                return countryRepository;
            }
        }

        private IPositionOfSteeringWheelRepository positionOfSteeringWheelRepository;
        public IPositionOfSteeringWheelRepository PositionOfSteeringWheelRepository
        {
            get
            {
                if (positionOfSteeringWheelRepository == null || !initializedRepositories.Contains(positionOfSteeringWheelRepository))
                {
                    positionOfSteeringWheelRepository = repositoryFactory.Get<PositionOfSteeringWheelRepository>(context);
                    initializedRepositories.Add(positionOfSteeringWheelRepository);
                }
                return positionOfSteeringWheelRepository;
            }
        }
        #endregion

        #region Constructors
        public UnitOfWork(IRepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
            context = new TypicalMirekEntities();
            initializedRepositories = new List<object>();
        }
        #endregion

        //TODO refreshing context each time, not so sure about that, but it works
        public void Save()
        {
            context.SaveChanges();
            context = new TypicalMirekEntities();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}