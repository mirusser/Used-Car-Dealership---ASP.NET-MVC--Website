using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Models.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly IRepositoryFactory repositoryFactory;
        private TypicalMirekEntities context { get; set; }
        #region Repositories

        private IBrandRepository brandRepository;
        public IBrandRepository BrandRepository
        {
            get
            {
                if (brandRepository == null)
                {
                    try
                    {
                        brandRepository = repositoryFactory.Get<BrandRepository>(context);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                return brandRepository;
            }
        }
        #endregion

        #region Constructors
        public UnitOfWork(IRepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
            context = new TypicalMirekEntities();
        }
        #endregion

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}