using System.Collections.Generic;
using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class SliderPhotoManager : Manager, ISliderPhotoManager
    {
        private readonly ISliderPhotoRepository sliderPhotoRepository;
        private readonly ICarPhotoRepository carPhotoRepository;
        private readonly ICarRepository carRepository;

        public SliderPhoto Add(SliderPhoto slider)
        {
            if (slider == null)
            {
                return null;
            }

            if (sliderPhotoRepository.GetById(slider.Id) != null)
            {
                return null;
            }

            sliderPhotoRepository.Add(slider);
            sliderPhotoRepository.Save();

            return slider;
        }


        public SliderPhotoManager(IRepositoryFactory repositoryFactory)
        {
            sliderPhotoRepository = repositoryFactory.Get<SliderPhotoRepository>();
            carPhotoRepository = repositoryFactory.Get<CarPhotoRepository>();
            carRepository = repositoryFactory.Get<CarRepository>();
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

        public CarPhoto GetCarPhoto(int carId, string photoName)
        {
            var car = carRepository.GetById(carId);
            return car.Photos.FirstOrDefault(it => it.Name == photoName);
        }

        public void Delete(int id)
        {
            var slideToDelete = sliderPhotoRepository.GetById(id);
            if (slideToDelete == null) return;
            sliderPhotoRepository.Delete(slideToDelete);
            sliderPhotoRepository.Save();
        }

        public void Delete(IList<int> id)
        {
            var slidesToDelete = sliderPhotoRepository.GetAll().Where(it => id.Any(it2 => it.CarId == it2));

            if (!slidesToDelete.Any()) return;
            foreach (var slide in slidesToDelete)
            {
                sliderPhotoRepository.Delete(slide);
            }
            sliderPhotoRepository.Save();
        }

        public void DeleteByCarId(int carId)
        {
            var sliderPhoto = sliderPhotoRepository.GetByCarId(carId);
            if (sliderPhoto != null)
            {
                Delete(sliderPhoto);
            }
        }

        public void Delete(SliderPhoto sliderPhoto)
        {
            if (sliderPhoto == null) return;
            sliderPhotoRepository.Delete(sliderPhoto);
            sliderPhotoRepository.Save();
        }

        public void DeleteAll()
        {
            foreach (var it in sliderPhotoRepository.GetAll())
            {
                sliderPhotoRepository.Delete(it);
            }
            sliderPhotoRepository.Save();
        }

        public void CheckIfAllCarExist()
        {
            foreach (var it in sliderPhotoRepository.GetAll())
            {
                if (carRepository.GetById(it.CarId) == null || carRepository.GetById(it.CarId).DeleteTime != null) //not exist or is deleted
                {
                    Delete(it);
                }
            }
        }

        public List<CarPhotoViewModel> GetAllAsCarPhotoViewModel()
        {
            var slider = new List<CarPhotoViewModel>();

            foreach (var it in sliderPhotoRepository.GetAll())
            {
                slider.Add(new CarPhotoViewModel
                {
                    imageName = GetName(it.CarPhotoId),
                    description = it.Car.MainData.Model.Brand.Name + " " + it.Car.MainData.Model.Name,
                    carId = it.Car.Id,
                    price = it.Car.Price
                });
            }

            return slider;
        }

        public IQueryable<SliderPhoto> GetAllSlides()
        {
            return sliderPhotoRepository.GetAll();
        }

        public void UpdateSliderPhotos(int[] ids)
        {
            foreach (var slide in sliderPhotoRepository.GetAll().ToArray().Where(slide => !ids.Contains(slide.CarId)))
            {
                sliderPhotoRepository.Delete(slide);
            }

            sliderPhotoRepository.Save();
        }
    }
}