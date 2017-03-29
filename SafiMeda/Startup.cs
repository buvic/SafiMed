using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SafiMed.Startup))]

namespace SafiMed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
