using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using TypicalMirek_UsedCarDealer.Logic.Factories;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    internal class CategoryManager : Manager, ICategoryManager
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryManager()
        {
            categoryRepository = DependencyResolver.Current.GetService<RepositoryFactory>().Get<CategoryRepository>();
        }

        public T Add<T>(T entity)
        {
            var category = entity as Category;

            categoryRepository.Add(category);
            categoryRepository.Save();

            return (T)Convert.ChangeType(category, typeof(T)); 
        }

        public T Modify<T>(T entity)
        {
            var category = entity as Category;

            categoryRepository.Update(category);
            categoryRepository.Save();

            return (T)Convert.ChangeType(category, typeof(T)); 
        }

        public void Delete(Category category)
        {
            categoryRepository.Delete(category);
            categoryRepository.Save();
        }


        public Category GetById(int id)
        {
            return categoryRepository.GetById(id);
        }
        public IQueryable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public void Dispose()
        {
            categoryRepository.Dispose();
        }
    }
}