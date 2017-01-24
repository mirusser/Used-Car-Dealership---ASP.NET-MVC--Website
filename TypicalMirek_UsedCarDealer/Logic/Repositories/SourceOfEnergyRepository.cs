using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class SourceOfEnergyRepository : BaseRepository<SourceOfEnergy, TypicalMirekEntities>, ISourceOfEnergyRepository
    {
        public SourceOfEnergyRepository()
        {
            
        }

        public SourceOfEnergyRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }
    }
}