using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public interface IBodyRepository : IBaseRepository<Body>
    {
        bool CheckIfBodyWithExactNameExists(string bodyName);
    }
}
