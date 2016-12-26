using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface ITypeManager : IManager
    {
        Models.Type Add(Models.Type type);
        Models.Type Modify(Models.Type type);
        void Delete(Models.Type type);
        Models.Type GetById(int id);
        IQueryable<Models.Type> GetAll();
        void Dispose();
    }
}
