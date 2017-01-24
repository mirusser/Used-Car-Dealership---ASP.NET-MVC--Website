using System.Linq;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface ITypeManager : IManager
    {
        Models.Type Add(Models.Type type);
        Models.Type Modify(Models.Type type);
        bool Delete(Models.Type type);
        Models.Type GetById(int id);
        IQueryable<Models.Type> GetAll();
        void Dispose();
    }
}
