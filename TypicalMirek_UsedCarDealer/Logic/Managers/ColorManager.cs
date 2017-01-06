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
    public class ColorManager : Manager, IColorManager
    {
        private readonly IColorRepository colorRepository;
        private readonly IAdditionalDataRepository additionalDataRepository;

        public ColorManager() {}

        public ColorManager(IRepositoryFactory repositoryFactory)
        {
            colorRepository = repositoryFactory.Get<ColorRepository>();
            additionalDataRepository = repositoryFactory.Get<AdditionalDataRepository>();
        }

        //TODO check if color exist
        public Color Add (Color color)
        {
            if (color == null)
            {
                return null;
            }

            if (colorRepository.GetById(color.Id) != null || colorRepository.GetByName(color.Name) != null)
            {
                return null;
            }

            colorRepository.Add(color);
            colorRepository.Save();

            return color;
        }

        //TODO check if color exist
        public Color Modify(Color color)
        {
            if (colorRepository.CheckIfEntityWithNameExists(color.Id, color.Name))
            {
                return null;
            }
            
            colorRepository.Update(color);
            colorRepository.Save();

            return color;
        }

        public bool Delete(Color color)
        {
            if (additionalDataRepository.CheckIfColorIsUsed(color.Id))
            {
                return false;
            }

            colorRepository.Delete(color);
            colorRepository.Save();
            return true;
        }

        public Color GetById(int id)
        {
            return colorRepository.GetById(id);
        }

        public IQueryable<Color> GetAll()
        {
            return colorRepository.GetAll();
        }

        public void Dispose()
        {
            colorRepository.Dispose();
        }
    }
}