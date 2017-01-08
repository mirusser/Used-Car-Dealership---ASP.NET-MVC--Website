using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface IEmailConfigurationManager : IManager
    {
        EmailConfiguration Add(EmailConfiguration emailConfiguration);
        EmailConfiguration GetActive();
        EmailConfiguration Modify(EmailConfiguration emailConfiguration);
        bool Delete(EmailConfiguration emailConfiguration);
        EmailConfiguration GetById(int id);
        IQueryable<EmailConfiguration> GetAll();
        void Dispose();
    }
}
