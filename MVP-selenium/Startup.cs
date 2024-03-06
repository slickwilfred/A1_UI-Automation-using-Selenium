using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVP_selenium.Startup))]
namespace MVP_selenium
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
