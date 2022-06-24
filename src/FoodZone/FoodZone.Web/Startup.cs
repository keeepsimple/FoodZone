using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(FoodZone.Web.Startup))]
namespace FoodZone.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
