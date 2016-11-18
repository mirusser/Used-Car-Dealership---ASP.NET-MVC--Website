﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class BodyRepository : BaseRepository<Body, TypicalMirekEntities>, IBodyRepository
    {
        public BodyRepository()
        {
            
        }

        public BodyRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }
    }
}