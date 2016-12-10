using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Factories
{
    public class UnitOfWorkFactory : Factory, IUnitOfWorkFactory
    {
        private readonly Dictionary<Type, object> InitializedUnitOfWork;

        public UnitOfWorkFactory()
        {
            InitializedUnitOfWork = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Get Unit of Work intance
        /// </summary>
        /// <typeparam name="T">Unit of Work class</typeparam>
        /// <returns></returns>
        public override T Get<T>()
        {
            var unitOfWork = InitializedUnitOfWork.SingleOrDefault(r => r.Key == typeof(T)).Value;

            if (unitOfWork == null)
            {
                unitOfWork = (T)Activator.CreateInstance(typeof(T), DependencyResolver.Current.GetService<TypicalMirekEntities>(), DependencyResolver.Current.GetService<RepositoryFactory>());
                InitializedUnitOfWork.Add(typeof(T), unitOfWork);
            }

            return (T)unitOfWork;
        }
    }
}