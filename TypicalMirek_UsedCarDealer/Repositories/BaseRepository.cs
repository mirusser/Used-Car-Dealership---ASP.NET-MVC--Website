using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Practices.ServiceLocation;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Repositories.Interfaces;

namespace TypicalMirek_UsedCarDealer.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : class
    {
        #region Properties
        private readonly ApplicationDbContext dbContext;
        protected DbSet<T> Set { get; set; }

        public IServiceLocator ServiceLocator1
        {
            get
            {
                return ServiceLocator;
            }

            set
            {
                ServiceLocator = value;
            }
        }

        private bool disposed = false;
        #endregion

        #region Constructors
        public BaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region Methods

        public virtual IQueryable<T> GetAll()
        {
            return Set;
        }

        public virtual T GetById(int id)
        {
            return Set.Find(id);
        }

        public virtual void Add(T entity)
        {
            Set.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbContext.Entry<T>(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            Set.Remove(Set.Find(id));
        }

        public virtual void Save()
        {
            dbContext.SaveChanges();
        }

        public virtual void Dispose()
        {
            if (disposed)
            {
                dbContext.Dispose();
                disposed = false;
            }
        }
        #endregion

    }
}