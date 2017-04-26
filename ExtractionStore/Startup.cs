using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExtractionStore.Startup))]
namespace ExtractionStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
