using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;

namespace TypicalMirek_UsedCarDealer.Logic.Factories
{
    public class ManagerFactory : Factory, IManagerFactory
    {
        private readonly Dictionary<Type, object> initializedManagers = new Dictionary<Type, object>();

        /// <summary>
        /// Get manager instance
        /// </summary>
        /// <typeparam name="T">Manager class</typeparam>
        /// <returns></returns>
        public override T Get<T>()
        {
            CheckIfImplementsInterface<T, IManager>();

            var manager = initializedManagers.SingleOrDefault(r => r.Key == typeof(T)).Value;

            if (manager == null)
            {
                manager = (T)Activator.CreateInstance(typeof(T), null);
                initializedManagers.Add(typeof(T), manager);
            }

            return (T)manager;
        }

    }
}