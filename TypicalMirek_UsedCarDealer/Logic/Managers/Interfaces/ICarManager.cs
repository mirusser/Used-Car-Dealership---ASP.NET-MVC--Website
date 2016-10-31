using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface ICarManager : IManager
    {
        AddCarViewModel Add(AddCarViewModel car);
        AddCarViewModel Modify(AddCarViewModel car);
        AddCarViewModel CreateAddCarViewModel();
        IQueryable<Car> GetAllCars();
        IList<DisplayCarViewModel> GetAllCarsToDisplay();
        Car GetCarById(int id);
        AddCarViewModel GetAddCarViewModel(int id);
        CarDetailsViewModel GetCarDetailsViewModelById(int id);
        void Dispose();
    }
}