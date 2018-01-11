using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(B2CDemo.Startup))]

namespace B2CDemo
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      ConfigureAuth(app); 
      app.UseNancy();

      // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
    }
  }
}
