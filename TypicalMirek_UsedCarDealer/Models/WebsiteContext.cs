using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class WebsiteContext
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string SiteName { get; set; }
        [Required]
        [AllowHtml]
        public string Context { get; set; }
    }
}