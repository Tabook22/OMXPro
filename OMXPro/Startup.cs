using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OMXPro.Startup))]
namespace OMXPro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
