using Type = TypicalMirek_UsedCarDealer.Models.Type;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public interface ITypeRepository : IBaseRepository<Type>
    {
        Type GetByName(string name);
        bool CheckIfTypeWithExactNameExists(string typeName);
    }
}
