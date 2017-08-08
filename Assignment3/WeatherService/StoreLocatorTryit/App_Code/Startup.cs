using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreLocatorTryit.Startup))]
namespace StoreLocatorTryit
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
