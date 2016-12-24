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

        public ColorManager() {}

        public ColorManager(IRepositoryFactory repositoryFactory)
        {
            colorRepository = repositoryFactory.Get<ColorRepository>();
        }

        //TODO check if color exist
        public T Add<T>(T entity)
        {
            var color = entity as Color;

            colorRepository.Add(color);
            colorRepository.Save();

            return (T)Convert.ChangeType(color, typeof(T));
        }

        //TODO check if color exist
        public T Modify<T>(T entity)
        {
            var color = entity as Color;

            colorRepository.Update(color);
            colorRepository.Save();

            return (T)Convert.ChangeType(color, typeof(T));
        }

        public void Delete(Color color)
        {
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
        }
    }
}