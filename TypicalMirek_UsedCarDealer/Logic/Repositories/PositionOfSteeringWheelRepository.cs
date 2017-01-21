using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class PositionOfSteeringWheelRepository : BaseRepository<PositionOfSteeringWheel, TypicalMirekEntities>, IPositionOfSteeringWheelRepository
    {
        public PositionOfSteeringWheelRepository()
        {
            
        }

        public PositionOfSteeringWheelRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }
    }
}