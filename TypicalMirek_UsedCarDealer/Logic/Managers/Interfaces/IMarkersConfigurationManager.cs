using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface IMarkersConfigurationManager : IManager
    {
        IQueryable<MarkersConfiguration> GetAll();

        MarkersConfiguration GetMapLocalization();

        IQueryable<MarkersConfiguration> GetAllMarkers();
        MarkersConfiguration GetMarkerById(int id);

        MarkersConfiguration AddMarker(MarkersConfiguration markersConfiguration);

        MarkersConfiguration ModifyMarker(MarkersConfiguration markersConfiguration);

        MarkersConfiguration AddOrModifyMapLocalization(MarkersConfiguration markersConfiguration);

        void DeleteMarker(MarkersConfiguration markersConfiguration);

        void Dispose();
    }
}
