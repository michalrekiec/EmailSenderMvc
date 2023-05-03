using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmailSenderMvc.Startup))]
namespace EmailSenderMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
