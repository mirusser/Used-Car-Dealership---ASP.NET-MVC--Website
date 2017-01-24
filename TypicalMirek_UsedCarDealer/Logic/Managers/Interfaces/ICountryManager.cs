using System.Linq;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface ICountryManager : IManager
    {
        Country Add(Country country);
        Country Modify(Country country);
        void Delete(Country country);
        Country GetById(int id);
        IQueryable<Country> GetAll();
        void Dispose();
    }
}
