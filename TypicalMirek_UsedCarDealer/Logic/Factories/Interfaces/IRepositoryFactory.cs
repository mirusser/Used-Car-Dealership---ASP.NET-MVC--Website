namespace TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces
{
    public interface IRepositoryFactory
    {
        T GetRepository<T>();
    }
}