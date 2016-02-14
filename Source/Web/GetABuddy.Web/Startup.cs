using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(GetABuddy.Web.Startup))]

namespace GetABuddy.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
