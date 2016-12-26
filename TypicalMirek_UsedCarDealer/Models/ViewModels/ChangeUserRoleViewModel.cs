using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models.ViewModels
{
    public class ChangeUserRoleViewModel
    {
        public ChangeUserRoleViewModel()
        {
            IsSucces = null;
        }

        [Required]
        [DisplayName("User name")]
        [StringLength(128, MinimumLength = 1, ErrorMessage = "This field must be at least 1 character")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Role name")]
        [StringLength(128, MinimumLength = 1, ErrorMessage = "This field must be at least 1 character")]
        public string RoleName { get; set; }
        public bool? IsSucces { get; set; }
    }
}