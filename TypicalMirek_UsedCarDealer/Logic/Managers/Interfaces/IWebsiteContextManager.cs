using System.Linq;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces
{
    public interface IWebsiteContextManager : IManager
    {
        IQueryable<WebsiteContext> GetAll();
        WebsiteContext GetById(int id);
        WebsiteContext GetContextByName(string name);
        WebsiteContext Add(WebsiteContext websiteContext);
        WebsiteContext Modify(WebsiteContext websiteContext);
        void Delete(WebsiteContext websiteContext);
        void Dispose();
    }
}
