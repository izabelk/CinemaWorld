using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CinemaWorld.Web.Startup))]
namespace CinemaWorld.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}