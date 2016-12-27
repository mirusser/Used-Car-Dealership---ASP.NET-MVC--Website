using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface ISliderPhotoManager : IManager
    {
        IList<string> GetNames();
        string GetName(int id);
        IQueryable<SliderPhoto> GetAllSlides();
    }
}
