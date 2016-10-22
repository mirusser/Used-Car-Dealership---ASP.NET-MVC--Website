using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;

namespace TypicalMirek_UsedCarDealer.Logic.Factories
{
    public class ManagerFactory
    {
        private readonly Dictionary<Type, object> initializedManagers = new Dictionary<Type, object>();

        private static Type assignableType => typeof(IManager);

        private bool CheckIfImplementsInterface<T>()
        {
            if (!typeof(T).GetInterfaces().Contains(assignableType))
            {
               throw new NotImplementedException($"{nameof(T)} not implementing {nameof(assignableType)}");
            }
            return true;
        }

    }
}