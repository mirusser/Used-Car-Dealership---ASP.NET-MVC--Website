using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface IColorManager : IManager
    {
        T Add<T>(T entity);
        T Modify<T>(T entity);
        void Delete(Color color);
        Color GetById(int id);
        IQueryable<Color> GetAll();
        void Dispose();
    }
}
