using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = TypicalMirek_UsedCarDealer.Models.Type;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public interface ITypeRepository : IBaseRepository<Type>
    {
        Type GetByName(string name);
    }
}
