using System.Collections.Generic;
using System.Linq;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface ISliderPhotoManager : IManager
    {
        SliderPhoto Add(SliderPhoto slider);
        IList<string> GetNames();
        string GetName(int id);
        CarPhoto GetCarPhoto(int carId, string photoName);
        IQueryable<SliderPhoto> GetAllSlides();
        void Delete(int id);
        void Delete(SliderPhoto sliderPhoto);
        void DeleteAll();
        void CheckIfAllCarExist();
        List<CarPhotoViewModel> GetAllAsCarPhotoViewModel();
        void UpdateSliderPhotos(int[] ids);
    }
}
