using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class ColorRepository : BaseRepository<Color, TypicalMirekEntities>, IColorRepository
    {
        public ColorRepository()
        {

        }

        public ColorRepository(TypicalMirekEntities entities) : base(entities)
        {

        }

        public Color GetByName(string name)
        {
            return Items.FirstOrDefault(c => c.Name == name);
        }

        public bool CheckIfEntityWithNameExists(int id, string name)
        {
            return Items.Any(c => c.Name == name && c.Id != id);
        }

        public bool CheckIfColorWithExactNameExists(string colorName)
        {
            return Items.FirstOrDefault(c => c.Name.Equals(colorName)) != null;
        }
    }
} 