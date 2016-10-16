using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class PositionOfSteeringWheel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Position { get; set; }
    }
}