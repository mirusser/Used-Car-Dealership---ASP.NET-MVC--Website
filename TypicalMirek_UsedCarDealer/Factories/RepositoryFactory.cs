using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Repositories.Interfaces;

namespace TypicalMirek_UsedCarDealer.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly Dictionary<Type, object> initializedRepositories = new Dictionary<Type, object>();

        /// <summary>
        /// Get repositoryinstance
        /// </summary>
        /// <typeparam name="T">Repository class</typeparam>
        /// <returns></returns>
        public T GetRepository<T>()
        {
            var repository = initializedRepositories.SingleOrDefault(r => r.Key == typeof(T)).Value;

            if (repository == null)
            {
                repository = (T)Activator.CreateInstance(typeof(T), null);
                initializedRepositories.Add(typeof(T), repository);
            }

            return (T)repository;
        }
    }
}