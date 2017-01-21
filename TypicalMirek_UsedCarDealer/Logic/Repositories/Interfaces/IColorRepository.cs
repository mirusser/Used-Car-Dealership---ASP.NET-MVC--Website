using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public interface IColorRepository : IBaseRepository<Color>
    {
        Color GetByName(string name);
        bool CheckIfEntityWithNameExists(int id, string name);
    }
}
