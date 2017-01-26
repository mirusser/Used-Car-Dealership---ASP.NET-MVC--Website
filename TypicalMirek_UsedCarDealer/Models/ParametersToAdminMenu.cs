using System.Collections.Generic;
using System.Linq;
using TypicalMirek_UsedCarDealer.Models.Enums;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class ParametersToAdminMenu
    {
        public IList<Values> Values { get; set; }
        public IQueryable<string> BrandNames { get; set; }
        public IQueryable<string> Cartypes { get; set; }
    }

    public class Values
    {
        public string Name { get; set; }
        public long Value { get; set; }
    }
}