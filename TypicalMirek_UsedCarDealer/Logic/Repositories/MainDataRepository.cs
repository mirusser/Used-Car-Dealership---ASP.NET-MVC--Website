﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}