using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Factories;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class CarBodyManager : Manager, ICarBodyManager
    {
        #region Properties
        private readonly IBodyRepository bodyRepository;
        private readonly ICarRepository carRepository;
        #endregion

        public CarBodyManager(IRepositoryFactory repositoryFactory)
        {
            bodyRepository = repositoryFactory.Get<BodyRepository>();
            carRepository = repositoryFactory.Get<CarRepository>();
        }

        public Body Add(Body body)
        {
            if (body.Id <= 0)
            {
                bodyRepository.Add(body);
                bodyRepository.Save();
            }

            return body;
        }

        public Body Modify(Body body)
        {
            var bodyToModify = bodyRepository.GetById(body.Id);
            if (bodyToModify != null)
            {
                bodyToModify.Name = body.Name;
                bodyRepository.Save();
            }

            return bodyToModify;
        }

        public bool Delete(int id)
        {
            var bodyToDelete = bodyRepository.GetById(id);
            if (bodyToDelete != null)
            {
                if (!carRepository.CheckIfExistCarForBodyId(id))
                {
                    bodyRepository.Delete(bodyToDelete);
                    bodyRepository.Save();
                    return true;
                }
            }
            return false;
        }

        public void Delete(Body body)
        {
            var bodyToDelete = bodyRepository.GetById(body.Id);
            if (bodyToDelete != null)
            {
                bodyRepository.Delete(bodyToDelete);
                bodyRepository.Save();
            }
        }

        public IQueryable<Body> GetAll()
        {
            return bodyRepository.GetAll();
        }

        public Body GetById(int id)
        {
            return bodyRepository.GetById(id);
        }

        public void Dispose()
        {
            bodyRepository.Dispose();
        }
    }
}