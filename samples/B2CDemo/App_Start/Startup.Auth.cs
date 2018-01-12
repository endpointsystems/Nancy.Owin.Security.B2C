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
      // configure cookie-base authentication.
      app.SetDefaultSignInAsAuthenticationType("Cookies");
      app.UseCookieAuthentication(new CookieAuthenticationOptions());
      
      // register all the OpenID connection policies.
      app.RegisterOpenIdConnectAuthPolicies(new OpenIdConfigHelper());

    }
  }
}