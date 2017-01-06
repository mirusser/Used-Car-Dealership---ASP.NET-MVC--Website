using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class ParametersToHome
    {
        public IList<CarPhotoViewModel> Slider { get; set; }
        public IList<CarPhotoViewModel> HotCars { get; set; }
        public IList<CarPhotoViewModel> NewCars { get; set; }
    }
}