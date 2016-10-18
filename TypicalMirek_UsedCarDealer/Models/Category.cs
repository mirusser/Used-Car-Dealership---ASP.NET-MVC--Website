using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}