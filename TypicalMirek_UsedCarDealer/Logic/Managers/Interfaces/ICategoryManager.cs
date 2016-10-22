using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    interface ICategoryManager: IManager
    {
        T Add<T>(T entity);
        T Modify<T>(T entity);
        void Delete(Category category);
        Category GetById(int id);
        IQueryable<Category> GetAll();
        void Dispose();
    }
}
