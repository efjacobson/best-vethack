using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(best_vethack3.Startup))]
namespace best_vethack3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
