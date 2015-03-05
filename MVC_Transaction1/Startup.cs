using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Transaction1.Startup))]
namespace MVC_Transaction1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
