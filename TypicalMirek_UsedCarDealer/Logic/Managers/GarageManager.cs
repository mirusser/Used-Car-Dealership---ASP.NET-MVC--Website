using System;
using System.Collections.Generic;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class GarageManager : IGarageManager
    {
        #region Repositories
        private readonly IGarageRepository garageRepository;
        private readonly IOrderRepository orderRepository;
        private readonly ICarRepository carRepository;
        #endregion

        #region Constructors
        public GarageManager() { }

        public GarageManager(IRepositoryFactory repositoryFactory)
        {
            garageRepository = repositoryFactory.Get<GarageRepository>();
            orderRepository = repositoryFactory.Get<OrderRepository>();
            carRepository = repositoryFactory.Get<CarRepository>();
        }
        #endregion

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

            if (garage.Orders == null)
            {
                garage.Orders = new List<Order>();
            }
            garage.Orders.Add(order);
            garageRepository.Save();

            markCarOrderFlag(carId, isInOrder: true);
        }

        public Order GetOrderById(int orderId)
        {
            return orderRepository.GetById(orderId);
        }

        public void DeleteOrderByEntity(Order order)
        {
            markCarOrderFlag(order.Car.Id, isInOrder: false);
            orderRepository.Delete(order);
            orderRepository.Save();
        }

        private void markCarOrderFlag(int carId, bool isInOrder)
        {
            var car = carRepository.GetById(carId);
            car.IsInOrder = isInOrder;
            carRepository.Save();
        }

        public void ConfirmOrder(int orderId)
        {
            var order = orderRepository.GetById(orderId);
            order.IsConfirmed = true;
            orderRepository.Save();
        }

        public void Dispose()
        {
            garageRepository.Dispose();
            orderRepository.Dispose();
            carRepository.Dispose();
        }
    }
}