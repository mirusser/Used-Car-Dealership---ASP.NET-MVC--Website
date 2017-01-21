using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class AdditionalDataRepository : BaseRepository<AdditionalData, TypicalMirekEntities>, IAdditionalDataRepository
    {
        public AdditionalDataRepository()
        {
            
        }

        public AdditionalDataRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }

        public bool CheckIfColorIsUsed(int colorId)
        {
            return Items.Any(a => a.ColorId == colorId);
        }
    }
}