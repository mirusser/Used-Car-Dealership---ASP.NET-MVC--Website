using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Logic.Helpers
{
    public static class MappingHelper
    {
        public static Car MappAddingCarViewModelToCarModel(AddCarViewModel addCarViewModel)
        {
            //TODO fill another properties of Car class
            return new Car()
            {
                MainData = new MainData()
                {
                    TypeId = addCarViewModel.TypeId,
                    CharacterId = addCarViewModel.CharacterId,
                    ModelId = addCarViewModel.ModelId
                },
                BodyId = addCarViewModel.BodyId,
                PropulsionId = addCarViewModel.PropulsionId,
                SourceOfEnergyId = addCarViewModel.SourceOfEnergyId
            };
        }
    }
}