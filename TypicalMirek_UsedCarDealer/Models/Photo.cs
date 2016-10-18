using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class Photo
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public Image Image { get; set; }
        public virtual Car Car { get; set; }
    }
}