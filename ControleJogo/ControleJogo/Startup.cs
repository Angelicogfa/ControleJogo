using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ControleJogo.Startup))]

namespace ControleJogo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Configure(app);
        }
    }
}
