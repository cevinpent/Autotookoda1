using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autotookoda1.Startup))]
namespace Autotookoda1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
