using System.Linq;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface IColorManager : IManager
    {
        Color Add (Color color);
        Color Modify(Color color);
        void Delete(Color color);
        Color GetById(int id);
        IQueryable<Color> GetAll();
        void Dispose();
    }
}
