using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class Order
    {
        public Order()
        {
            IsConfirmed = false;
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [MaxLength(128)]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public int CarId{ get; set; }
        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }

        public DateTime DateOfOrder { get; set; }
        public bool IsConfirmed { get; set; }
    }
}