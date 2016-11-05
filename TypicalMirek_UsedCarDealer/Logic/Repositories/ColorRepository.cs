using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public class ColorRepository : BaseRepository<Color, TypicalMirekEntities>, IColorRepository
    {
    }
}