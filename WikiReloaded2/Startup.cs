using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WikiReloaded2.Startup))]
namespace WikiReloaded2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
