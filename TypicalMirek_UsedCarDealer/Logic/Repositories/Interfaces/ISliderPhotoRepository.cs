using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public interface ISliderPhotoRepository : IBaseRepository<SliderPhoto>
    {
        SliderPhoto GetByCarId(int carId);
    }
}
