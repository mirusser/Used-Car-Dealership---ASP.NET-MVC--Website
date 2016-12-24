using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class CountryManager : Manager, ICountryManager
    {
        private readonly ICountryRepository countryRepository;

        public CountryManager() { }

        public CountryManager(IRepositoryFactory repositoryFactory)
        {
            countryRepository = repositoryFactory.Get<CountryRepository>();
        }

        //TODO check if country exist
        public T Add<T>(T entity)
        {
            var country = entity as Country;

            countryRepository.Add(country);
            countryRepository.Save();

            return (T)Convert.ChangeType(country, typeof(T));
        }

        //TODO check if country exist
        public T Modify<T>(T entity)
        {
            var country = entity as Country;

            countryRepository.Update(country);
            countryRepository.Save();

            return (T)Convert.ChangeType(country, typeof(T));
        }

        public void Delete(Country country)
        {
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
        }
    }
}