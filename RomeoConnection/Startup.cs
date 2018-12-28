using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RomeoConnection.Startup))]
namespace RomeoConnection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
