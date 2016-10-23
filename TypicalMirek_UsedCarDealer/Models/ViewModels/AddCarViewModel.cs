using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TypicalMirek_UsedCarDealer.Models.ViewModels
{
    public class AddCarViewModel
    {
        public int Id { get; set; }

        #region MainData
        [Display(Name = "Type")]
        public int TypeId { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        [Display(Name = "Character")]
        public int CharacterId { get; set; }
        public IEnumerable<SelectListItem> Characters { get; set; }
        [Display(Name = "Model")]
        public int ModelId { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; }
        #endregion

        [Display(Name = "Body")]
        public int BodyId { get; set; }
        public IEnumerable<SelectListItem> Bodies { get; set; }
        [Display(Name = "Propulsion")]
        public int PropulsionId { get; set; }
        public IEnumerable<SelectListItem> Propulsions { get; set; }
        [Display(Name = "Source of energy")]
        public int SourceOfEnergyId { get; set; }
        public IEnumerable<SelectListItem> SourcesOfEnergy { get; set; }

        public ICollection<CarPhoto> Photos { get; set; }
    }
}