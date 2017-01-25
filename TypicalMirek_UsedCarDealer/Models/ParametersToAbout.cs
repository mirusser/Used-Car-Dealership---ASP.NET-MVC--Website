using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class ParametersToAbout
    {
        public MarkersConfiguration MapLocalization { get; set; }
        public IQueryable<MarkersConfiguration> Markerslocalizations { get; set; }
        public string PageContent { get; set; }
    }
}