using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class TypeRepository : BaseRepository<TypicalMirek_UsedCarDealer.Models.Type, TypicalMirekEntities>, ITypeRepository
    {
        public TypeRepository()
        {
            
        }

        public TypeRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }

        public Models.Type GetByName(string name)
        {
            return Items.SingleOrDefault(t => t.Name.Equals(name));
        }
    }
}