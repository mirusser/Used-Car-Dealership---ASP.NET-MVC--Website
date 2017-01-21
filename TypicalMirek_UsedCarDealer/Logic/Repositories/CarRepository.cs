using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class CarRepository : BaseRepository<Car, TypicalMirekEntities>, ICarRepository
    {
        public CarRepository(){ }

        public CarRepository(TypicalMirekEntities entities) : base(entities) { }

        public bool CheckIfExistCarForBodyId(int bodyId)
        {
            return Items.Any(c => c.BodyId.Equals(bodyId));
        }

        public bool CheckIfExistCarForBrandId(int brandId)
        {
            return Items.Any(c => c.MainData.Model.BrandId.Equals(brandId));
        }

        public bool CheckIfExistCarForCharacterId(int characterId)
        {
            return Items.Any(c => c.MainData.CharacterId.Equals(characterId));
        }

        public bool CheckIfExistCarForTypeId(int typeId)
        {
            return Items.Any(c => c.MainData.TypeId.Equals(typeId));
        }
    }
}