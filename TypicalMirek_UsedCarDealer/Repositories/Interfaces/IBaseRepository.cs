using System.Collections.Generic;

namespace TypicalMirek_UsedCarDealer.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IList<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
        void Dispose();
    }
}
