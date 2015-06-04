using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImageUploader.Startup))]
namespace ImageUploader
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
