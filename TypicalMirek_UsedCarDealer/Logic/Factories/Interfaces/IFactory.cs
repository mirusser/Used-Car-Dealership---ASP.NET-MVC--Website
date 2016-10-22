using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces
{
    public interface IFactory
    {
        T Get<T>();
    }
}
