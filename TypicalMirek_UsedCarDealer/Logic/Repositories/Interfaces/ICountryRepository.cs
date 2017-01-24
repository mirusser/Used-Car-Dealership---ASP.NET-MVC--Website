using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        bool CheckIfCountryWithExactNameExists(string countryName);
    }
}
