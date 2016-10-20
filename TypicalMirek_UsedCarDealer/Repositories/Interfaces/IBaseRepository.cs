using System.Collections.Generic;
using System.Linq;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Repositories.Interfaces
{
    public interface IBaseRepository<T, TEntity>
        where T : class
         where TEntity : ApplicationDbContext, new()
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
