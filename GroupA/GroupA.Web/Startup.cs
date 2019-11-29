using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GroupA.Web.Startup))]
namespace GroupA.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
