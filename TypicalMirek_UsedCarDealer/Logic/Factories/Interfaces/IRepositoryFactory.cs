using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces
{
    public interface IRepositoryFactory : IFactory
    {
        //Any additional method here
        T Get<T>(TypicalMirekEntities context);
    }
}