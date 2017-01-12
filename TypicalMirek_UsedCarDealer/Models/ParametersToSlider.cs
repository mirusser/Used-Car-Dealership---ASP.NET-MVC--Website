using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class ParametersToSlider
    {
        public IList<CarPhotoViewModel> SliderPhotos { get; set; }
        public IList<CarPhotos> CarsPhotos { get; set; }

    }

    public class CarPhotos
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public virtual ICollection<CarPhoto> Photos { get; set; }
    }
}