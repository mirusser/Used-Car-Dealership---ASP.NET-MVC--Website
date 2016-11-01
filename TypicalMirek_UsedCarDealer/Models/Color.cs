using System.ComponentModel.DataAnnotations;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class Color : BasicModel
    {
        [Key]
        [Required]
        public new int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public new string Name { get; set; }
    }
}