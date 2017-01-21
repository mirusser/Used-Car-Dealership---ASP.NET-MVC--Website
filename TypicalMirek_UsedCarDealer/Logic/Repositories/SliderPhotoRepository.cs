﻿using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class SliderPhotoRepository : BaseRepository<SliderPhoto, TypicalMirekEntities>, ISliderPhotoRepository
    {
        public SliderPhotoRepository()
        {
            
        }

        public SliderPhotoRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }
    }
}