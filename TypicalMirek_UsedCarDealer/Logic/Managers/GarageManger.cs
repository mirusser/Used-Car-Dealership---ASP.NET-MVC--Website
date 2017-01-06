using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class GarageManger : IGarageManager
    {
        private readonly IGarageRepository garageRepository;

        public GarageManger() { }

        public GarageManger(IRepositoryFactory repositoryFactory)
        {
            garageRepository = repositoryFactory.Get<GarageRepository>();
        }

        public Garage GetGarageByUserId(string userId)
        {
            return string.IsNullOrEmpty(userId) ? garageRepository.GetGarageByUserId(userId) : createUserGarage(userId);
        }

        private Garage createUserGarage(string userId)
        {
            var garage = new Garage
            {
                UserId = userId,
                Orders = null
            };

            garageRepository.Add(garage);
            garageRepository.Save();
            return garage;
        }
    }
}