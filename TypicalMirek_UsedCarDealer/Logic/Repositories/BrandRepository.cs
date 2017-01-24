using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class BrandRepository : BaseRepository<Brand, TypicalMirekEntities>, IBrandRepository
    {
        public BrandRepository() { }
        public BrandRepository(TypicalMirekEntities entities) : base(entities) { }

        public bool CheckIfBrandWithExactNameExists(string brandName)
        {
            return Items.FirstOrDefault(b => b.Name.Equals(brandName)) != null;
        }
    }
}