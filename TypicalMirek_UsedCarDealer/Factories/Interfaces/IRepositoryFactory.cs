namespace TypicalMirek_UsedCarDealer.Factories.Interfaces
{
    public interface IRepositoryFactory
    {
        T GetRepository<T>();
    }
}