using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Factories;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class CarManager : Manager, ICarManager
    {
        private ICarRepository carRepository;

        public CarManager() { }

        public CarManager(RepositoryFactory repositoryFactory)
        {
            carRepository = repositoryFactory.Get<CarRepository>();
        }

        public AddCarViewModel CreateAddCarViewModel()
        {
            return new AddCarViewModel();
        }
    }
}