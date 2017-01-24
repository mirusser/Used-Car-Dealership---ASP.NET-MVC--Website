using System.Linq;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface ICharacterManager : IManager
    {
        Character Add(Character character);
        Character Modify(Character character);
        bool Delete(Character character);
        Character GetById(int id);
        IQueryable<Character> GetAll();
        void Dispose();
    }
}
