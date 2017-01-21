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
        #region Properties
        private readonly IBrandRepository brandRepository;
        private readonly ICarRepository carRepository;
        #endregion

        #region Constructors
        public BrandManager(IRepositoryFactory repositoryFactory)
        {
            brandRepository = repositoryFactory.Get<BrandRepository>();
            carRepository = repositoryFactory.Get<CarRepository>();
        }
        #endregion

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
            if (brandRepository.GetById(brand.Id) != null || brandRepository.CheckIfBrandWithExactNameExists(brand.Name))
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
            if (brandToModify == null || brandRepository.CheckIfBrandWithExactNameExists(brand.Name))
            {
                return null;
            }
            brandToModify.Name = brand.Name;
            brandToModify.Description = brand.Description;
            brandRepository.Save();
            return brand;
        }

        public bool Delete(Brand brand)
        {
            if (brand != null)
            {
                if (!carRepository.CheckIfExistCarForBrandId(brand.Id))
                {
                    brandRepository.Delete(brand);
                    brandRepository.Save();
                    return true;
                }
            }
            return false;
        }

        public void Dispose()
        {
            brandRepository.Dispose();
            carRepository.Dispose();
        }
    }
}