using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antlr.Runtime;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class CarRepository : BaseRepository<Car, TypicalMirekEntities>, ICarRepository
    {
        public CarRepository()
        {
            
        }

        public CarRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }
    }
}