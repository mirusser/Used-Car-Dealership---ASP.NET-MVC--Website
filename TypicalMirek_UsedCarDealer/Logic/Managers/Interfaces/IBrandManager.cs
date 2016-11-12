using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface IBrandManager : IManager
    {
        IQueryable<Brand> GetAll();
        Brand GetById(int id);
        Brand Add(Brand brand);
        Brand Modify(Brand brand);
        void Delete(Brand brand);
        void Dispose();
    }
}
