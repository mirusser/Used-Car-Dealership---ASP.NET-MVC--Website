using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class ColorManager : Manager, IColorManager
    {
        #region Properties
        private readonly IColorRepository colorRepository;
        private readonly IAdditionalDataRepository additionalDataRepository;
        #endregion

        #region Constructors
        public ColorManager() { }

        public ColorManager(IRepositoryFactory repositoryFactory)
        {
            colorRepository = repositoryFactory.Get<ColorRepository>();
            additionalDataRepository = repositoryFactory.Get<AdditionalDataRepository>();
        }
        #endregion

        public Color Add(Color color)
        {
            if (color == null)
            {
                return null;
            }

            if (colorRepository.GetById(color.Id) != null || colorRepository.CheckIfColorWithExactNameExists(color.Name))
            {
                return null;
            }

            colorRepository.Add(color);
            colorRepository.Save();

            return color;
        }

        public Color Modify(Color color)
        {
            var colorToModify = colorRepository.GetById(color.Id);
            var isModyfiedNameEqual = color.Name.Equals(colorToModify.Name);

            if (colorRepository.CheckIfColorWithExactNameExists(color.Name) && !isModyfiedNameEqual)
            {
                return null;
            }
            colorToModify.Name = color.Name;
            colorRepository.Save();
            return colorToModify;
        }

        public void Delete(Color color)
        {
            if (additionalDataRepository.CheckIfColorIsUsed(color.Id))
            {
                var additionalDatas = additionalDataRepository.GetAllAdditionalDatasByColorId(color.Id);
                additionalDatas.ToList().ForEach(a =>
                {
                    a.ColorId = null;
                });
                additionalDataRepository.Save();
            }

            colorRepository.Delete(color);
            colorRepository.Save();
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
            additionalDataRepository.Dispose();
        }
    }
}