using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class Model
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        public string Version { get; set; }

        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand{ get; set; }
    }
}