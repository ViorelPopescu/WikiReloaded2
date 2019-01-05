using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WikiReloaded2.Models;

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
