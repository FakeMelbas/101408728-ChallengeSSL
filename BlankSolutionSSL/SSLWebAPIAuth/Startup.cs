using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SSLWebAPIAuth.Startup))]
namespace SSLWebAPIAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
