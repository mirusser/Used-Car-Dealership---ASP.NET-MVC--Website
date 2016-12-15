using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class ModelRepository : BaseRepository<Model, TypicalMirekEntities>, IModelRepository
    {
        public ModelRepository()
        {
            
        }

        public ModelRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }
    }
}