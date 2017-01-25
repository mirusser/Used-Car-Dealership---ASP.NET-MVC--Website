using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class MarkersConfiguration
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public bool IsMarker { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
    }
}