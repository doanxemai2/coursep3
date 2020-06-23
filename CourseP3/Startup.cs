using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseP3.Startup))]
namespace CourseP3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
