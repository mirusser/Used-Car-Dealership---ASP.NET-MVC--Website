using System.Collections.Generic;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class CarPhotosToSlider
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public virtual IEnumerable<string> PhotosNames { get; set; }
    }

    public class CarToSlider
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
    }
}