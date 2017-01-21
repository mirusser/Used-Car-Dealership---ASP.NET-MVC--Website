using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces
{
    public interface IAdditionalDataRepository :  IBaseRepository<AdditionalData>
    {
        bool CheckIfColorIsUsed(int colorId);
    }
}
