using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public interface IBrandRepository : IBaseRepository<Brand>
    {
        bool CheckIfBrandWithExactNameExists(string brandName);
    }
}
