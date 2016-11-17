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
        //private readonly IBrandRepository brandRepository;

        private readonly UnitOfWork unitOfWork;

        public BrandManager(IRepositoryFactory repositoryFactory)
        {
            unitOfWork = new UnitOfWork(repositoryFactory);
            //brandRepository = repositoryFactory.Get<BrandRepository>();
        }

        public IQueryable<Brand> GetAll()
        {
            return unitOfWork.BrandRepository.GetAll();
        }

        public Brand GetById(int id)
        {
            return unitOfWork.BrandRepository.GetById(id);
        }

        public Brand Add(Brand brand)
        {
            if (unitOfWork.BrandRepository.GetById(brand.Id) != null && unitOfWork.BrandRepository.GetAll().FirstOrDefault(b => b.Name.Equals(brand.Name)) != null)
            {
                return null;
            }
            unitOfWork.BrandRepository.Add(brand);
            unitOfWork.Save();
            return brand;
        }

        public Brand Modify(Brand brand)
        {
            var brandToModify = unitOfWork.BrandRepository.GetById(brand.Id);
            if (brandToModify == null)
            {
                return null;
            }
            brandToModify.Name = brand.Name;
            brandToModify.Description = brand.Description;
            unitOfWork.Save();
            return brand;
        }

        public void Delete(Brand brand)
        {
            unitOfWork.BrandRepository.Delete(brand);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            //brandRepository.Dispose();
            unitOfWork.Dispose();
        }
    }
}