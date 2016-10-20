using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Web;
using Microsoft.Ajax.Utilities;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;
using TypicalMirek_UsedCarDealer.Repositories.Interfaces;

namespace TypicalMirek_UsedCarDealer.Repositories
{
    public class BaseRepository<T, TEntity> : IBaseRepository<T, TEntity>, IDisposable
        where T : class
        where TEntity : ApplicationDbContext, new()
    {
        #region Properties
        protected TEntity Entities { get; private set; }
        protected DbSet<T> Set => Entities.Set<T>();
        public IQueryable<T> Items => Set.AsQueryable();
        #endregion

        #region Constructors
        public BaseRepository()
        {
            Entities = new TEntity();
        }

        public BaseRepository(TEntity entities)
        {
            Entities = entities;
        }
        #endregion

        #region Methods
        public virtual IQueryable<T> GetAll()
        {
            return Items;
        }

        public virtual IQueryable<T> Query(Expression<Func<T, bool>> query)
        {
            return Items.Where(query);
        }

        public virtual T GetById(int id)
        {
            return Items.AsEnumerable().SingleOrDefault(i =>
                i.GetType().GetProperty("Id") != null && (int)i.GetType().GetProperty("Id").GetValue(i, null) == id);
        }

        public virtual void Add(T entity)
        {
            Entities.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            Entities.Entry<T>(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            Delete(GetById(id));
        }

        public virtual void Delete(T entity)
        {
            Entities.Set<T>().Remove(entity);
        }

        public virtual void Save()
        {
            try
            {
                Entities.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public void RefreshDbContext()
        {
            Entities = new TEntity();
        }

        public virtual void Dispose()
        {
            Entities?.Dispose();
        }
        #endregion

    }
}