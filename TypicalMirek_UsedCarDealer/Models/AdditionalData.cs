using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class AdditionalData
    {
        [Required]
        public int Id { get; set; }

        public int NumberOfSeats { get; set; }
        public int YearOfProduction { get; set; }
        public int NumberOfOwners { get; set; }
        public decimal EngineCapacity { get; set; }
        public decimal FuelTankCapacity { get; set; }
        public int EnginePower { get; set; }
        public decimal Length { get; set; }
        public decimal Mass { get; set; }
        public virtual Color Color { get; set; }
        public decimal Milleage { get; set; }
        public bool Damaged { get; set; }

        public virtual AdditionalEquipment AdditionalEquipment { get; set; }

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