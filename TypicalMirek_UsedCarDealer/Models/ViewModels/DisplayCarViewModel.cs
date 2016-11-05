using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models.ViewModels
{
    public class DisplayCarViewModel
    {
        public DisplayCarViewModel(Model carModel)
        {
            Name = $"{carModel.Brand.Name} {carModel.Name} {carModel.Version}";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CarImagePath { get; set; }
        public string CarImageName { get; set; }
    }
}