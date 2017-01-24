using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class Garage
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [MaxLength(128)]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}