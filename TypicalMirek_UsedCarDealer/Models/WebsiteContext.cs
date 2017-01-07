using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class WebsiteContext
    {
        [Key]
        [Required]
        public new int Id { get; set; }
        [Required]
        public string SiteName { get; set; }
        [Required]
        public string Context { get; set; }
    }
}