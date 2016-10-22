using System.Linq;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public interface IBaseRepository<T>
        where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T item);
        void Save();
        void Dispose();
    }
}
