using System.Linq;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public interface ICarPhotoRepository : IBaseRepository<CarPhoto>
    {
        IQueryable<CarPhoto> GetAllCarPhotosByCarId(int carId);
    }
}
