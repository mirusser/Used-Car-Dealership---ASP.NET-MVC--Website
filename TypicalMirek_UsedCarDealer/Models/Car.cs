using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class Car
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int MainDataId { get; set; }
        [ForeignKey("MainDataId")]
        public virtual MainData MainData { get; set; }

        public int BodyId { get; set; }
        [ForeignKey("BodyId")]
        public virtual Body Body { get; set; }

        public int PropulsionId { get; set; }
        [ForeignKey("PropulsionId")]
        public virtual Propulsion Propulsion { get; set; }

        public int SourceOfEnergyId { get; set; }
        [ForeignKey("SourceOfEnergyId")]
        public virtual SourceOfEnergy SourceOfEnergy { get; set; }

        public int? AdditionalDataId { get; set; }
        [ForeignKey("AdditionalDataId")]
        public virtual AdditionalData AdditionalData { get; set; }

        public virtual ICollection<CarPhoto> Photos { get; set; }
    }
}