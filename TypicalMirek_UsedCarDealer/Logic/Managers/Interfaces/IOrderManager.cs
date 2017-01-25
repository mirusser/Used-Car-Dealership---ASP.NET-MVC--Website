using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface IOrderManager : IManager
    {
        bool Delete(int id);
        Order GetById(int id);
        IQueryable<Order> GetAll();
        void Dispose();
    }
}
