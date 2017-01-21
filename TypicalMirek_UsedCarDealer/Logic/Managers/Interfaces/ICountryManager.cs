using System.Linq;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface ICountryManager : IManager
    {
        T Add<T>(T entity);
        T Modify<T>(T entity);
        void Delete(Country country);
        Country GetById(int id);
        IQueryable<Country> GetAll();
        void Dispose();
    }
}
