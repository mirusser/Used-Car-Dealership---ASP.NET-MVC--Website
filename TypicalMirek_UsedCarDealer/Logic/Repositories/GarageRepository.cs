﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Migrations;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class GarageRepository : BaseRepository<Garage, TypicalMirekEntities>, IGarageRepository
    {
        public Garage GetGarageByUserId(string userId)
        {
            return Items.SingleOrDefault(g => g.UserId.Equals(userId));
        }
    }
}