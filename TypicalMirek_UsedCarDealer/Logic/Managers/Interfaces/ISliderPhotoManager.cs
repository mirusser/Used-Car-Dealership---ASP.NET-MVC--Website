using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface ISliderPhotoManager : IManager
    {
        IList<string> GetNames();
    }
}
