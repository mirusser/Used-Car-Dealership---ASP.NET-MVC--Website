using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface IGarageManager : IManager
    {
        Garage GetGarageByUserId(string userId);
        void OrderCar(int carId, string userId);
        Order GetOrderById(int orderId);
        void DeleteOrderByEntity(Order order);
        void ConfirmOrder(int orderId);
        void Dispose();
    }
}
