﻿using System.ComponentModel.DataAnnotations;

namespace TypicalMirek_UsedCarDealer.Models.ViewModels
{
    public class EmailFormViewModel
    {
        [Required, Display(Name = "Your name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Your email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required]
        public string Message { get; set; }
    }
}