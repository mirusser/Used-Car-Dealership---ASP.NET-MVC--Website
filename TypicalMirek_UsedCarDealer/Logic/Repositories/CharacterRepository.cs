using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class CharacterRepository : BaseRepository<Character, TypicalMirekEntities>, ICharacterRepository
    {
        public CharacterRepository()
        {
            
        }

        public CharacterRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }
    
        public bool CheckIfCharacterWithExactNameExists(string character)
        {
            return Items.FirstOrDefault(c => c.Name.Equals(character)) != null;
        }
    }
}