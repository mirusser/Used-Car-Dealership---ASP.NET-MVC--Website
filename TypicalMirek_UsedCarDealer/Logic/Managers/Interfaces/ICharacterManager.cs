using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface ICharacterManager : IManager
    {
        Character Add(Character character);
        Character Modify(Character character);
        void Delete(Character character);
        Character GetById(int id);
        IQueryable<Character> GetAll();
        void Dispose();
    }
}
