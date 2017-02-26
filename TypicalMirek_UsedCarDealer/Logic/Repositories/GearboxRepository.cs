using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class GearboxRepository : BaseRepository<Gearbox, TypicalMirekEntities>, IGearboxRepository
    {
        public GearboxRepository()
        {
            
        }

        public GearboxRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }

        public override IQueryable<Gearbox> GetAll()
        {
            return base.GetAll().OrderBy(x => x.Name);
        }
    }
}