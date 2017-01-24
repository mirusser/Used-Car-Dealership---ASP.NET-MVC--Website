using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class SliderPhoto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int CarPhotoId { get; set; }
        [ForeignKey("CarPhotoId")]
        public virtual CarPhoto CarPhoto { get; set; }

        public int CarId { get; set; }
        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
    }
}