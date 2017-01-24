using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TypicalMirek_UsedCarDealer.Models.ViewModels
{
    public class CarDetailsViewModel
    {
        public int Id { get; set; }

        #region MainData
        [Display(Name = "Type")]
        public string Type { get; set; }
        [Display(Name = "Character")]
        public string Character { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public long numberOfViews { get; set; }

        #region Model
        [Display(Name = "Brand")]
        public string Brand { get; set; }
        public string ModelName { get; set; }
        public string ModelVersion { get; set; }
        #endregion
        #endregion

        #region Additional Data
        [Display(Name = "Year of production")]
        public int? YearOfProduction { get; set; }
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
        public bool? Damaged { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }
        [Display(Name = "Gearbox")]
        public string Gearbox { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "Position of steering wheel")]
        public string PositionOfSteeringWheel { get; set; }

        #region Additional equipment
        public bool? Climatisation { get; set; }
        public bool? AdditionalWheels { get; set; }
        public bool? Towbar { get; set; }
        public bool? Radio { get; set; }
        #endregion
        #endregion

        [Display(Name = "Body")]
        public string Body { get; set; }
        [Display(Name = "Propulsion")]
        public string Propulsion { get; set; }
        [Display(Name = "Source of energy")]
        public string SourceOfEnergy { get; set; }

        public ICollection<CarPhoto> Photos { get; set; }
    }
}