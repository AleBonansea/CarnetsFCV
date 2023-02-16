using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarnetsFCV.Startup))]
namespace CarnetsFCV
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
