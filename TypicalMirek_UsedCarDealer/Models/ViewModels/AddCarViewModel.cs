using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models.ViewModels
{
    public class AddCarViewModel
    {
        public int Id { get; set; }

        #region MainData
        public IList<Type> Types { get; set; }
        public IList<Character> Characters { get; set; }
        public IList<Model> Models { get; set; }
        public IList<Brand> Brands { get; set; }

        #endregion

        public IList<Body> Bodies { get; set; }
        public IList<Propulsion> Propulsions { get; set; }
        public IList<SourceOfEnergy> SourcesOfEnergy { get; set; }

        public ICollection<CarPhoto> Photos { get; set; }
    }
}