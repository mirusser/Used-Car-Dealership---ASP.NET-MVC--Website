using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class ParametersToCarList
    {
        public List<CarDetailsViewModel> Cars { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; set; }
        public IQueryable<string> BrandList { get; set; }
        public IQueryable<string> ModelList { get; set; }
        public IQueryable<string> BodyList { get; set; }
        public IQueryable<string> FuelList { get; set; }
        public List<string> SortByList { get; set; }
    }
}