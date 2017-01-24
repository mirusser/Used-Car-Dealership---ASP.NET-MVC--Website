using System.Collections.Generic;
using System.Linq;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class ParametersToCarList
    {
        //car list
        public List<CarDetailsViewModel> Cars { get; set; }

        //for dropdownlists in view
        public IQueryable<string> BodyList { get; set; }
        public IQueryable<string> BrandList { get; set; }
        public IQueryable<string> CharacterList { get; set; }
        public IQueryable<string> ColorList { get; set; }
        public IQueryable<string> FuelList { get; set; }
        public IQueryable<string> GearboxList { get; set; }
        public IQueryable<int> NumberOfSeatsList { get; set; }
        public IQueryable<string> PropulsionList { get; set; }
        public IQueryable<string> SortByList { get; set; }

        //for pagination
        public int NumberOfPages { get; set; }
    }
}