using System.Linq;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface IEmailConfigurationManager : IManager
    {
        EmailConfiguration Add(EmailConfiguration emailConfiguration);
        EmailConfiguration GetActive();
        EmailConfiguration Modify(EmailConfiguration emailConfiguration);
        bool Delete(EmailConfiguration emailConfiguration);
        void SetActive(int id);
        EmailConfiguration GetById(int id);
        IQueryable<EmailConfiguration> GetAll();
        void Dispose();
    }
}
