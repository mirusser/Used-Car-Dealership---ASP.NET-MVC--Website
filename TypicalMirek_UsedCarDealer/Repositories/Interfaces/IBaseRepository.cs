using System.Collections.Generic;
using System.Linq;

namespace TypicalMirek_UsedCarDealer.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
        void Dispose();
    }
}
