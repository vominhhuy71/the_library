using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(library.Startup))]
namespace library
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
