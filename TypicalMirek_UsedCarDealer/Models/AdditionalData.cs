using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class AdditionalData
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Year of production")]
        public int YearOfProduction { get; set; }

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
        public decimal? Length { get; set; }
        public decimal? Mass { get; set; }
        public decimal? Milleage { get; set; }
        public bool? Damaged { get; set; }

        public int AdditionalEquipmentId { get; set; }
        [ForeignKey("AdditionalEquipmentId")]
        public virtual AdditionalEquipment AdditionalEquipment { get; set; }

        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }

        public int GearboxId { get; set; }
        [ForeignKey("GearboxId")]
        public virtual Gearbox GearBox { get; set; }

        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public int PositionOfSteeringWheelId { get; set; }
        [ForeignKey("PositionOfSteeringWheelId")]
        public virtual PositionOfSteeringWheel PositionOfSteeringWheel { get; set; }
    }
}