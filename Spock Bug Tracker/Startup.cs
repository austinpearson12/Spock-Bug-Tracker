using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Spock_Bug_Tracker.Startup))]
namespace Spock_Bug_Tracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
