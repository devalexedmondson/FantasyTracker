using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FantasyTracker.Startup))]
namespace FantasyTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
