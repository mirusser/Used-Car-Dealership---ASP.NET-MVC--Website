using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;

namespace TypicalMirek_UsedCarDealer.Logic.Factories
{
    public abstract class Factory : IFactory
    {
        //protected virtual bool CheckIfImplementsInterface<T>()
        //{
        //    var assignableType = typeof(T);

        //    if (!typeof(T).GetInterfaces().Contains(assignableType))
        //    {
        //        var errorMessage = $"{nameof(T)} not implementing {nameof(assignableType)}";
        //        throw new NotImplementedException(errorMessage);
        //    }
        //    return true;
        //}

        protected virtual bool CheckIfImplementsInterface<T, TInterface>()
        {
            var assignableType = typeof(TInterface);

            if (!typeof(T).GetInterfaces().Contains(assignableType))
            {
                var errorMessage = $"{nameof(T)} not implementing {nameof(assignableType)}";
                throw new NotImplementedException(errorMessage);
            }
            return true;
        }

        public virtual T Get<T>()
        {
            throw new NotImplementedException();
        }
    }
}