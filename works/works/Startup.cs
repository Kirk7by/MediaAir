using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(works.Startup))]
namespace works
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
