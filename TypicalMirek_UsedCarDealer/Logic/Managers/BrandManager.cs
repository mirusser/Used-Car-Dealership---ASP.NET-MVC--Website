using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.UnitOfWork;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class BrandManager : Manager, IBrandManager
    {
        private readonly IBrandRepository brandRepository;

        //private readonly UnitOfWork unitOfWork;

        public BrandManager(IRepositoryFactory repositoryFactory)
        {
           // unitOfWork = unitOfWorkFactory.Get<UnitOfWork>();
            brandRepository = repositoryFactory.Get<BrandRepository>();
        }

        public IQueryable<Brand> GetAll()
        {
            return brandRepository.GetAll();
        }

        public Brand GetById(int id)
        {
            return brandRepository.GetById(id);
        }

        public Brand Add(Brand brand)
        {
            if (brandRepository.GetById(brand.Id) != null && brandRepository.GetAll().FirstOrDefault(b => b.Name.Equals(brand.Name)) != null)
            {
                return null;
            }
            brandRepository.Add(brand);
            brandRepository.Save();
            return brand;
        }

        public Brand Modify(Brand brand)
        {
            var brandToModify = brandRepository.GetById(brand.Id);
            if (brandToModify == null)
            {
                return null;
            }
            brandToModify.Name = brand.Name;
            brandToModify.Description = brand.Description;
            brandRepository.Save();
            return brand;
        }

        public void Delete(Brand brand)
        {
            brandRepository.Delete(brand);
            brandRepository.Save();
        }

        public void Dispose()
        {
            brandRepository.Dispose();
            //unitOfWork.Dispose();
        }
    }
}