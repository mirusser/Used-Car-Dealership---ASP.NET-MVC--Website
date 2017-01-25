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
    public class OrderManager : Manager, IOrderManager
    {
        #region Properties
        private readonly IOrderRepository orderRepository;
        #endregion

        #region Constructors
        public OrderManager(IRepositoryFactory repositoryFactory)
        {
            orderRepository = repositoryFactory.Get<OrderRepository>();
        }
        #endregion

        public bool Delete(int id)
        {
            var order = GetById(id);
            if (order != null)
            {
                orderRepository.Delete(order);
                orderRepository.Save();
                return true;
            }
            return false;
        } 

        public Order GetById(int id)
        {
            return orderRepository.GetById(id);
        }

        public IQueryable<Order> GetAll()
        {
            return orderRepository.GetAll();
        }

        public void Dispose()
        {
            orderRepository.Dispose();
        }
    }
}