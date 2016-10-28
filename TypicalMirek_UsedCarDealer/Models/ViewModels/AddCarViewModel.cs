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

        #region Additional Data
        [Display(Name = "Number of Seats")]
        public int? NumberOfSeats { get; set; }
        [Display(Name = "Number of previous owners")]
        public int? NumberOfOwners { get; set; }
        [Display(Name = "Engine Capacity")]
        public decimal? EngineCapacity { get; set; }
        [Display(Name = "Fuel tank capacity")]
        public decimal? FuelTankCapacity { get; set; }
        [Display(Name = "Engine power")]
        public int? EnginePower { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        public decimal? Length { get; set; }
        public decimal? Mass { get; set; }
        public decimal? Milleage { get; set; }
        public bool Damaged { get; set; }
        public int? YearOfProduction { get; set; }

        [Display(Name = "Color")]
        public int? ColorId { get; set; }
        public IQueryable<SelectListItem> Colors { get; set; }
        [Display(Name = "Gearbox")]
        public int? GearboxId { get; set; }
        public IQueryable<SelectListItem> Gearboxes { get; set; }
        [Display(Name = "Country")]
        public int? CountryId { get; set; }
        public IQueryable<SelectListItem> Countries { get; set; }
        [Display(Name = "Position of steering wheel")]
        public int? PositionOfSteeringWheelId { get; set; }
        public IQueryable<SelectListItem> PositionsOfSteeringWheel { get; set; }

        #region Additional equipment
        public bool? Climatisation { get; set; }
        public bool? AdditionalWheels { get; set; }
        public bool? Towbar { get; set; }
        public bool? Radio { get; set; }
        #endregion

        #endregion

        #region MainData
        [Display(Name = "Type")]
        public int TypeId { get; set; }
        public IQueryable<SelectListItem> Types { get; set; }
        [Display(Name = "Character")]
        public int CharacterId { get; set; }
        public IQueryable<SelectListItem> Characters { get; set; }

        #region Model
        //Model?
        [Display(Name = "Model")]
        public int ModelId { get; set; }
        public IQueryable<SelectListItem> Models { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string ModelName { get; set; }
        public string Version { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public IQueryable<SelectListItem> Brands { get; set; }
        #endregion
        #endregion

        [Display(Name = "Body")]
        public int BodyId { get; set; }
        public IQueryable<SelectListItem> Bodies { get; set; }
        [Display(Name = "Propulsion")]
        public int PropulsionId { get; set; }
        public IQueryable<SelectListItem> Propulsions { get; set; }
        [Display(Name = "Source of energy")]
        public int SourceOfEnergyId { get; set; }
        public IQueryable<SelectListItem> SourcesOfEnergy { get; set; }

        public ICollection<CarPhoto> Photos { get; set; }
    }
}