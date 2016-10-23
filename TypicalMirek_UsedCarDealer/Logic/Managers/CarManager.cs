using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

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

        public AddCarViewModel Add(AddCarViewModel car)
        {
            var carToAdd = new Car
            {

            };

            carRepository.Add(carToAdd);
            carRepository.Save();

            return null;
        }
        public AddCarViewModel CreateAddCarViewModel()
        {
            //var foo = typeRepository.GetAll().Select(x => new SelectListItem
            //{
            //    Value = x.Id.ToString(),
            //    Text = x.Name
            //});
            //var types = new SelectList(foo, "Value", "Text");

            //var characters = characterRepository.GetAll().Select(x => new SelectListItem
            //{
            //    Value = x.Id.ToString(),
            //    Text = x.Name
            //});
            //var brands = brandRepository.GetAll().Select(x => new SelectListItem
            //{
            //    Value = x.Id.ToString(),
            //    Text = x.Name
            //});
            //var bodies = bodyRepository.GetAll().Select(x => new SelectListItem
            //{
            //    Value = x.Id.ToString(),
            //    Text = x.Name
            //});
            //var propulsions = propulsionRepository.GetAll().Select(x => new SelectListItem
            //{
            //    Value = x.Id.ToString(),
            //    Text = x.Name
            //});
            //var sourcesOfEnergy = sourceOfEnergyRepository.GetAll().Select(x => new SelectListItem
            //{
            //    Value = x.Id.ToString(),
            //    Text = x.Name
            //});

            var types = getSelectListItem(typeRepository.GetAll());
            var characters = getSelectListItem(characterRepository.GetAll());
            var brands = getSelectListItem(brandRepository.GetAll());
            var bodies = getSelectListItem(bodyRepository.GetAll());
            var propulsions = getSelectListItem(propulsionRepository.GetAll());
            var sourcesOfEnergy = getSelectListItem(sourceOfEnergyRepository.GetAll());

            return new AddCarViewModel
            {
                Types = types,
                Characters = characters,
                Brands = brands,
                Bodies = bodies,
                Propulsions = propulsions,
                SourcesOfEnergy = sourcesOfEnergy
            };
        }

        private IQueryable<SelectListItem> getSelectListItem<T>(IQueryable<T> query) where T : BasicModel
        {
            
            return query.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
    }
}