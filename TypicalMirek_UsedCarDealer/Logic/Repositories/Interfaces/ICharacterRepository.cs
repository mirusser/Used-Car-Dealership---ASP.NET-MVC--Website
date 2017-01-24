using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public interface ICharacterRepository : IBaseRepository<Character>
    {
        bool CheckIfCharacterWithExactNameExists(string character);
    }
}
