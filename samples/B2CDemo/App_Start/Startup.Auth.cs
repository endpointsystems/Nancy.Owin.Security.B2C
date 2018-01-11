using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Nancy.OWin.Security.MSGraph.B2C;
using Owin;

namespace B2CDemo
{
  public partial class Startup
  {
    public void ConfigureAuth(IAppBuilder app)
    {
      app.SetDefaultSignInAsAuthenticationType("Cookies");
      app.UseCookieAuthentication(new CookieAuthenticationOptions());
      app.RegisterOpenIdConnectAuthPolicies(new OpenIdConfigHelper());

    }
  }
}