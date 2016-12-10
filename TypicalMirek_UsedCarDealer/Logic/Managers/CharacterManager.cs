using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class CharacterManager : Manager, ICharacterManager
    {
        private readonly ICharacterRepository characterRepository;

        public CharacterManager(IRepositoryFactory repositoryFactory)
        {
            characterRepository = repositoryFactory.Get<CharacterRepository>();
        }

        public Character Add(Character character)
        {
            characterRepository.Add(character);
            characterRepository.Save();
            return character;
        }

        public Character Modify(Character character)
        {
            var characterToModify = characterRepository.GetById(character.Id);

            if (characterToModify != null)
            {
                characterToModify.Name = character.Name;
                characterRepository.Save();
            }

            return characterToModify;
        }

        public void Delete(Character character)
        {
            var characterToDelete = characterRepository.GetById(character.Id);

            if (characterToDelete != null)
            {
                characterRepository.Delete(characterToDelete);
                characterRepository.Save();
            }
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
        }
    }
}