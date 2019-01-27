using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cobom.Startup))]
namespace cobom
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
