using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TypicalMirek_UsedCarDealer.Models.ViewModels
{
    public class ChangeUserRoleViewModel
    {
        public ChangeUserRoleViewModel()
        {
            IsSucces = null;
            Roles = new List<SelectListItem>();
        }

        [Required]
        [DisplayName("User name")]
        [StringLength(128, MinimumLength = 1, ErrorMessage = "This field must be at least 1 character")]
        public string UserName { get; set; }
        [DisplayName("User role")]
        public List<SelectListItem> Roles { get; set; }
        [Required]
        public string SelectedRoleId { get; set; }
        public bool? IsSucces { get; set; }
    }
}