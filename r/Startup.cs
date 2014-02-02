using System.Data.Entity;
using Microsoft.Owin;
using Owin;
using r.Models;

[assembly: OwinStartupAttribute(typeof(r.Startup))]
namespace r
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Database.SetInitializer(new LinkSeed());
        }
    }
}
