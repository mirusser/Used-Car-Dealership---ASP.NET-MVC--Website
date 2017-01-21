using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class CharacterManager : Manager, ICharacterManager
    {
        #region Properties
        private readonly ICharacterRepository characterRepository;
        private readonly ICarRepository carRepository;
        #endregion

        #region Constructors
        public CharacterManager(IRepositoryFactory repositoryFactory)
        {
            characterRepository = repositoryFactory.Get<CharacterRepository>();
            carRepository = repositoryFactory.Get<CarRepository>();
        }
        #endregion

        public Character Add(Character character)
        {
            if (characterRepository.GetById(character.Id) != null || characterRepository.CheckIfCharacterWithExactNameExists(character.Name))
            {
                return null;
            }

            characterRepository.Add(character);
            characterRepository.Save();
            return character;
        }

        public Character Modify(Character character)
        {
            var characterToModify = characterRepository.GetById(character.Id);
            var isModyfiedNameEqual = character.Name.Equals(characterToModify.Name);

            if (characterRepository.CheckIfCharacterWithExactNameExists(character.Name) && !isModyfiedNameEqual)
            {
                return null;
            }

            characterToModify.Name = character.Name;
            characterRepository.Save();
            return characterToModify;
        }

        public bool Delete(Character character)
        {
            if (character != null)
            {
                if (!carRepository.CheckIfExistCarForBrandId(character.Id))
                {
                    characterRepository.Delete(character);
                    characterRepository.Save();
                    return true;
                }
            }
            return false;
        }

        public Character GetById(int id)
        {
            return characterRepository.GetById(id);
        }

        public IQueryable<Character> GetAll()
        {
            return characterRepository.GetAll();
        }

        public void Dispose()
        {
            characterRepository.Dispose();
            carRepository.Dispose();
        }
    }
}