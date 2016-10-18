using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class AdditionalEquipment
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public bool Climatisation { get; set; }
        public bool AdditionalWheels { get; set; }
        public bool Towbar { get; set; }
        public bool Radio { get; set; }
    }
}