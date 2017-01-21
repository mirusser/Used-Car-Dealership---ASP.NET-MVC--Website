using System.Linq;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface IBrandManager : IManager
    {
        IQueryable<Brand> GetAll();
        Brand GetById(int id);
        Brand Add(Brand brand);
        Brand Modify(Brand brand);
        bool Delete(Brand brand);
        void Dispose();
    }
}
