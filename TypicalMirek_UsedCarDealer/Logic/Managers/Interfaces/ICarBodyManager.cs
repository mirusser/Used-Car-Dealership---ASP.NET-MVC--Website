using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface ICarBodyManager : IManager
    {
        Body Add(Body body);
        Body Modify(Body body);
        void Delete(int id);
        void Delete(Body body);
        IQueryable<Body> GetAll();
        Body GetById(int id);
        void Dispose(); 
    }
}
