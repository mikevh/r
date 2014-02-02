using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(r.Startup))]
namespace r
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
