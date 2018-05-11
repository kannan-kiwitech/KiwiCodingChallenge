using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodingChallenge1.Startup))]
namespace CodingChallenge1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
