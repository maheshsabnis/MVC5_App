using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5_App.Startup))]
namespace MVC5_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
