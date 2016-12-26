using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class MainDataRepository : BaseRepository<MainData, TypicalMirekEntities>, IMainDataRepository
    {
        public MainDataRepository()
        {
            
        }

        public MainDataRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }

        public bool Contains<T>(T entity)
        {
            var type = entity.GetType();
            if (type == typeof(Models.Type))
            {
                var carType = entity as Models.Type;
                return Items.FirstOrDefault(m => m.Type.Id == carType.Id) != null;
            }

            if (type == typeof(Models.Model))
            {
                var carModel = entity as Models.Model;
                return Items.FirstOrDefault(m => m.Type.Id == carModel.Id) != null;
            }

            if (type  == typeof(Models.Character))
            {
                var carCharacter = entity as Models.Character;
                return Items.FirstOrDefault(m => m.Type.Id == carCharacter.Id) != null;
            }
            return false;
        }
    }
}