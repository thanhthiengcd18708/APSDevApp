using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APSDevApp.Startup))]
namespace APSDevApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
