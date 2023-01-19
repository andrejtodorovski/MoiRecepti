using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoiRecepti.Startup))]
namespace MoiRecepti
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
