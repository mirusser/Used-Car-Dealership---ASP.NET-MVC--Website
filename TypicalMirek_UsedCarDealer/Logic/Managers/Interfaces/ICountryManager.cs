using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
