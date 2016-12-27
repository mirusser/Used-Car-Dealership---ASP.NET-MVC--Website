using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class SliderPhotoManager : Manager, ISliderPhotoManager
    {
        private readonly ISliderPhotoRepository sliderPhotoRepository;
        private readonly ICarPhotoRepository carPhotoRepository;

        public SliderPhotoManager(IRepositoryFactory repositoryFactory)
        {
            sliderPhotoRepository = repositoryFactory.Get<SliderPhotoRepository>();
            carPhotoRepository = repositoryFactory.Get<CarPhotoRepository>();
        }

        public IList<string> GetNames()
        {
            var sliderPhotoNames = new List<string>();
            sliderPhotoRepository.GetAll().ToList().ForEach(p =>
            {
                sliderPhotoNames.Add(carPhotoRepository.GetById(p.CarPhotoId).Name);
            });
            return sliderPhotoNames;
        }

        public string GetName(int id)
        {
            return carPhotoRepository.GetById(id).Name;
        }

        public IQueryable<SliderPhoto> GetAllSlides()
        {
            return sliderPhotoRepository.GetAll();
        }
    }
}