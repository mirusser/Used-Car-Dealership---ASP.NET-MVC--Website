using TypicalMirek_UsedCarDealer.Models.Enums;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class ParametersToAdminMenu
    {
        public SidebarChoose? Chose { get; set; }
        public int? Id { get; set; }
        public virtual ChangeUserRoleViewModel ChangeUserRoleViewModel { get; set; }
    }
}