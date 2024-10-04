using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TSSurance.Startup))]
namespace TSSurance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
