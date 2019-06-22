using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sigex.Startup))]
namespace Sigex
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
