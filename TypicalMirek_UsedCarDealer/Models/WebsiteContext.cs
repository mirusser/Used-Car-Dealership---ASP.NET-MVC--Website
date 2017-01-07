using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [AllowHtml]
        public string Context { get; set; }
    }
}