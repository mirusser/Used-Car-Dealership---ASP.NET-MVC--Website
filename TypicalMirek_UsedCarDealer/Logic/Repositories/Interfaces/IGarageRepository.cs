using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public interface IGarageRepository : IBaseRepository<Garage>
    {
        Garage GetGarageByUserId(string userId);
    }
}
