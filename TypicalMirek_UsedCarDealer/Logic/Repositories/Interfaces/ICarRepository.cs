using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        bool CheckIfExistCarForBodyId(int bodyId);
        bool CheckIfExistCarForBrandId(int bodyId);
        bool CheckIfExistCarForCharacterId(int characterId);
        bool CheckIfExistCarForTypeId(int typeId);
    }
}
