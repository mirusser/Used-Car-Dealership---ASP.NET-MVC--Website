using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class MainData
    {
        [Required]
       public int Id { get; set; }

        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual Type Type { get; set; }

        public int CharacterId { get; set; }
        [ForeignKey("CharacterId")]
        public virtual Character Character { get; set; }

        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public virtual Model Model { get; set; }
    }
}