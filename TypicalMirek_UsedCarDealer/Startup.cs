using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TypicalMirek_UsedCarDealer.Startup))]
namespace TypicalMirek_UsedCarDealer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
