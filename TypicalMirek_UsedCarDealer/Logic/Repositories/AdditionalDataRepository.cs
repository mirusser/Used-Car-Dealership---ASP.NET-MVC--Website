using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class AdditionalDataRepository : BaseRepository<AdditionalData, TypicalMirekEntities>, IAdditionalDataRepository
    {
        public AdditionalDataRepository()
        {
            
        }

        public AdditionalDataRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }

        public IQueryable<AdditionalData> GetAllAdditionalDatasByColorId(int countryId)
        {
            return Items.Where(a => a.ColorId == countryId);
        }

        public IQueryable<AdditionalData> GetAllAdditionalDatasByCountryId(int colorId)
        {
            return Items.Where(a => a.CountryId == colorId);
        }

        public bool CheckIfColorIsUsed(int colorId)
        {
            return Items.Any(a => a.ColorId == colorId);
        }

        public bool CheckIfCountryIsUsed(int countryId)
        {
            return Items.Any(a => a.CountryId == countryId);
        }
    }
}