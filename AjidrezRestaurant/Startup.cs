using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AjidrezRestaurant.Startup))]
namespace AjidrezRestaurant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
