using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KB_Web.Startup))]
namespace KB_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
