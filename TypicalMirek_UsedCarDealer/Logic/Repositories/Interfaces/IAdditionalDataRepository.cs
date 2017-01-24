using System.Linq;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public interface IAdditionalDataRepository : IBaseRepository<AdditionalData>
    {
        IQueryable<AdditionalData> GetAllAdditionalDatasByColorId(int countryId);
        IQueryable<AdditionalData> GetAllAdditionalDatasByCountryId(int colorId);
        bool CheckIfColorIsUsed(int colorId);
        bool CheckIfCountryIsUsed(int countryId);
    }
}
