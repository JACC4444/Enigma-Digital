using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Enigma_Digital.Startup))]
namespace Enigma_Digital
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
