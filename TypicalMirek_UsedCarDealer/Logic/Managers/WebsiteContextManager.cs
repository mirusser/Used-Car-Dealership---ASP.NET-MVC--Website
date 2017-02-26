using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class WebsiteContextManager : Manager, IWebsiteContextManager
    {
        private readonly IWebsiteContextRepository websiteContextRepository;

        public WebsiteContextManager(IRepositoryFactory repositoryFactory)
        {
            websiteContextRepository = repositoryFactory.Get<WebsiteContextRepository>();
        }

        public IQueryable<WebsiteContext> GetAll()
        {
            return websiteContextRepository.GetAll();
        }

        public WebsiteContext GetById(int id)
        {
            return websiteContextRepository.GetById(id);
        }

        public WebsiteContext GetContextByName(string name)
        {
            return websiteContextRepository.GetAll().FirstOrDefault(it => it.SiteName == name);
        }

        public WebsiteContext Add(WebsiteContext websiteContext)
        {
            if (websiteContextRepository.GetById(websiteContext.Id) != null && websiteContextRepository.GetAll().FirstOrDefault(it => it.SiteName == websiteContext.SiteName) != null)
            {
                return null;
            }
            websiteContextRepository.Add(websiteContext);
            websiteContextRepository.Save();
            return websiteContext;
        }

        public WebsiteContext Modify(WebsiteContext websiteContext)
        {
            var websiteContextToModify = GetContextByName(websiteContext.SiteName);
            if (websiteContextToModify == null)
            {
                return null;
            }
            websiteContextToModify.SiteName = websiteContext.SiteName;
            websiteContextToModify.Context = websiteContext.Context;
            websiteContextRepository.Save();
            return websiteContext;
        }

        public void Delete(WebsiteContext websiteContext)
        {
            websiteContextRepository.Delete(websiteContext);
            websiteContextRepository.Save();
        }

        public void Dispose()
        {
            websiteContextRepository.Dispose();
        }
    }
}