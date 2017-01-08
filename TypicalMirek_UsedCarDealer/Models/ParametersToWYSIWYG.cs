using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class ParametersToWysiwyg
    {
        public string ActionNameForPost { get; set; }
        public string ControllerNameForPost { get; set; }
        public string Context { get; set; }
        public int? Height { get; set; }
        public int? MinHeight { get; set; }
        public int? MaxHeight { get; set; }
        public bool? Focus { get; set; }
    }
}