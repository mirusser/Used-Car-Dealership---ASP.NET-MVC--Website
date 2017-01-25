using System.Globalization;
using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class MarkersConfigurationManager : Manager, IMarkersConfigurationManager
    {
        private readonly IMarkersConfigurationRepository markersConfigurationRepository;

        public MarkersConfigurationManager(IRepositoryFactory repositoryFactory)
        {
            markersConfigurationRepository = repositoryFactory.Get<MarkersConfigurationRepository>();
        }

        public IQueryable<MarkersConfiguration> GetAll()
        {
            return markersConfigurationRepository.GetAll();
        }

        public MarkersConfiguration GetMapLocalization()
        {
            return markersConfigurationRepository.GetAll().FirstOrDefault(it => it.IsMarker == false);
        }

        public IQueryable<MarkersConfiguration> GetAllMarkers()
        {
            return markersConfigurationRepository.GetAll().Where(it => it.IsMarker == true);
        }

        public MarkersConfiguration AddMarker(MarkersConfiguration markersConfiguration)
        {
            if (markersConfiguration.IsMarker == false)
            {
                return null;
            }

            if (markersConfigurationRepository.GetById(markersConfiguration.Id) != null &&
                markersConfigurationRepository.GetAll().FirstOrDefault(
                    it => it.Latitude.ToString(CultureInfo.CurrentCulture) == markersConfiguration.Latitude.ToString(CultureInfo.CurrentCulture) &&
                    it.Longitude.ToString(CultureInfo.CurrentCulture) == markersConfiguration.Longitude.ToString(CultureInfo.CurrentCulture)) != null)
            {
                return null;
            }
            markersConfigurationRepository.Add(markersConfiguration);
            markersConfigurationRepository.Save();
            return markersConfiguration;
        }

        public MarkersConfiguration ModifyMarker(MarkersConfiguration markersConfiguration)
        {
            var markerConfigurationToModify = markersConfigurationRepository.GetById(markersConfiguration.Id);
            if (markerConfigurationToModify == null)
            {
                return null;
            }

            markerConfigurationToModify.Latitude = markersConfiguration.Latitude;
            markerConfigurationToModify.Longitude = markersConfiguration.Longitude;
            markerConfigurationToModify.Info = markersConfiguration.Info;
            markerConfigurationToModify.Title = markersConfiguration.Title;

            markersConfigurationRepository.Save();
            return markersConfiguration;
        }

        public MarkersConfiguration AddOrModifyMapLocalization(MarkersConfiguration markersConfiguration)
        {
            if (markersConfiguration.IsMarker == true)
            {
                return null;
            }

            var mapLocalizationToModify = GetMapLocalization();

            if (mapLocalizationToModify == null)
            {
                //not exist, add new
                markersConfigurationRepository.Add(markersConfiguration);
            }
            else
            {
                //exist, modify
                mapLocalizationToModify.Latitude = markersConfiguration.Latitude;
                mapLocalizationToModify.Longitude = markersConfiguration.Longitude;
            }

            markersConfigurationRepository.Save();
            return markersConfiguration;
        }

        public void DeleteMarker(MarkersConfiguration markersConfiguration)
        {
            markersConfigurationRepository.Delete(markersConfiguration);
            markersConfigurationRepository.Save();
        }

        public void Dispose()
        {
            markersConfigurationRepository.Dispose();
        }
    }
}