using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class CarPhotoRepository : BaseRepository<CarPhoto, TypicalMirekEntities>, ICarPhotoRepository
    {
        public CarPhotoRepository() { }

        public CarPhotoRepository(TypicalMirekEntities entities) : base(entities){}

        public IQueryable<CarPhoto> GetAllCarPhotosByCarId(int carId)
        {
            return Items.Where(p => p.CarId.Equals(carId));
        }
    }
}