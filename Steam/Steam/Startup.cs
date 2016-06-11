using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Steam.Startup))]
namespace Steam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
