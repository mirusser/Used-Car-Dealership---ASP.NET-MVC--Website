using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class CountryRepository : BaseRepository<Country, TypicalMirekEntities>, ICountryRepository
    {
        public CountryRepository()
        {
            
        }

        public CountryRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }

        public bool CheckIfCountryWithExactNameExists(string countryName)
        {
            return Items.FirstOrDefault(c => c.Name.Equals(countryName)) != null;
        }
    }
}