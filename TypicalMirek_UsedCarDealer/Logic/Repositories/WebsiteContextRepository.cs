using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class WebsiteContextRepository : BaseRepository<WebsiteContext, TypicalMirekEntities>, IWebsiteContextRepository
    {
        public WebsiteContextRepository()
        {

        }

        public WebsiteContextRepository(TypicalMirekEntities entities) : base(entities)
        {

        }
    }
}