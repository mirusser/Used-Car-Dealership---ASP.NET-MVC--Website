using System.Collections.Generic;
using System.Linq;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface ICarManager : IManager
    {
        AddCarViewModel Add(AddCarViewModel car);
        AddCarViewModel Modify(AddCarViewModel car);
        void RemoveCarById(int id);
        AddCarViewModel CreateAddCarViewModel();
        IQueryable<Car> GetAllCars();
        IList<DisplayCarViewModel> GetAllCarsToDisplay();
        IQueryable<Car> GetCarsForAddToSlider(int[] idsCarInSlider);
        Car GetCarById(int id);
        AddCarViewModel GetAddCarViewModel(int id);
        CarDetailsViewModel GetCarDetailsViewModelById(int id);
        AddCarViewModel SetCarSelecLists(AddCarViewModel addCarViewModel);
        List<CarPhoto> GetAllCarPhotos(int carId);
        void IncrementNumberOfViews(int id);
        void Dispose();
    }
}