using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MimoChallengeBackend.Startup))]
namespace MimoChallengeBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
