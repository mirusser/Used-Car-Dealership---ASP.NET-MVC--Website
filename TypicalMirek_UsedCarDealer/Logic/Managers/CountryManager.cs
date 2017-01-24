using System;
using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class CountryManager : Manager, ICountryManager
    {
        #region Properties
        private readonly ICountryRepository countryRepository;
        private readonly IAdditionalDataRepository additionalDataRepository;
        #endregion

        #region Constructors
        public CountryManager() { }

        public CountryManager(IRepositoryFactory repositoryFactory)
        {
            countryRepository = repositoryFactory.Get<CountryRepository>();
            additionalDataRepository = repositoryFactory.Get<AdditionalDataRepository>();
        }
        #endregion

        public Country Add(Country country)
        {
            if (country == null)
            {
                return null;
            }

            if (countryRepository.GetById(country.Id) != null || countryRepository.CheckIfCountryWithExactNameExists(country.Name))
            {
                return null;
            }

            countryRepository.Add(country);
            countryRepository.Save();

            return country;
        }

        public Country Modify(Country country)
        {
            var countryToModify = countryRepository.GetById(country.Id);
            var isModyfiedNameEqual = country.Name.Equals(countryToModify.Name);

            if (countryRepository.CheckIfCountryWithExactNameExists(country.Name) && !isModyfiedNameEqual)
            {
                return null;
            }
            countryToModify.Name = country.Name;
            countryRepository.Save();
            return countryToModify;
        }

        public void Delete(Country country)
        {
            if (additionalDataRepository.CheckIfCountryIsUsed(country.Id))
            {
                var additionalDatas = additionalDataRepository.GetAllAdditionalDatasByCountryId(country.Id);
                additionalDatas.ToList().ForEach(a =>
                {
                    a.CountryId = null;
                });
                additionalDataRepository.Save();
            }

            countryRepository.Delete(country);
            countryRepository.Save();
        }

        public Country GetById(int id)
        {
            return countryRepository.GetById(id);
        }

        public IQueryable<Country> GetAll()
        {
            return countryRepository.GetAll();
        }

        public void Dispose()
        {
            countryRepository.Dispose();
            additionalDataRepository.Dispose();
        }
    }
}