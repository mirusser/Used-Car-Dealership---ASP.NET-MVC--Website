using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class CategoryRepository : BaseRepository<Category, TypicalMirekEntities>, ICategoryRepository
    {
        public CategoryRepository()
        {
            
        }

        public CategoryRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }
    }
}