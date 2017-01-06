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
        Color Add (Color color);
        Color Modify(Color color);
        bool Delete(Color color);
        Color GetById(int id);
        IQueryable<Color> GetAll();
        void Dispose();
    }
}
