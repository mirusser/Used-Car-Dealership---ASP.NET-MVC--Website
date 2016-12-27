using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class ParametersToHome
    {
        public IList<ImageInfo> Slider { get; set; }
        public IList<ImageInfo> HotCars { get; set; }
    }

    public class ImageInfo
    {
        public string imageName { get; set; }
        public string description { get; set; }
    }
}