using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public interface IMainDataRepository : IBaseRepository<MainData>
    {
        bool Contains<T>(T entity);
    }
}
