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
    public class GarageManager : IGarageManager
    {
        private readonly IGarageRepository garageRepository;
        private readonly IOrderRepository orderRepository;

        public GarageManager() { }

        public GarageManager(IRepositoryFactory repositoryFactory)
        {
            garageRepository = repositoryFactory.Get<GarageRepository>();
            orderRepository = repositoryFactory.Get<OrderRepository>();
        }

        public Garage GetGarageByUserId(string userId)
        {
            return garageRepository.GetGarageByUserId(userId) ?? createUserGarage(userId);
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

        public void OrderCar(int carId, string userId)
        {
            var garage = GetGarageByUserId(userId);
            var order = new Order
            {
                CarId = carId,
                UserId = userId,
                DateOfOrder = DateTime.Now,
            };

            //orderRepository.Add(order);
            //orderRepository.Save();

            if (garage.Orders == null)
            {
                garage.Orders = new List<Order>();
            }
            garage.Orders.Add(order);
            garageRepository.Save();
        }
    }
}