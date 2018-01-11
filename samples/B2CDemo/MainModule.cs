using Microsoft.Owin.Security;
using Nancy;
using Nancy.OWin.Security.MSGraph.Extensions;
using Nancy.Responses;

namespace B2CDemo
{
  public class MainModule : NancyModule
  {
    private readonly OpenIdConfigHelper helper = new OpenIdConfigHelper();
    private readonly AuthenticationProperties props = new AuthenticationProperties()
    {
      RedirectUri = "/"
    };

    public MainModule()
    {
      Get("/",  args => View["Index"]);
      Get("/Claims",  args => View["Claims"]);
      Get("/Login", args =>
      {
        Context.GetAuthenticationManager().Challenge(props, helper.Policies[0]);
        return HttpStatusCode.Unauthorized;
      });
      Get("/Profile", args =>
      {
        if (Context.CurrentUser == null)
          return new RedirectResponse("/");
        Context.GetAuthenticationManager().Challenge(props, helper.Policies[1]);
        return (object) HttpStatusCode.Unauthorized;
      });
      Get("/SignOut", args =>
      {
        if (Context.CurrentUser == null)
          return new RedirectResponse("/");
        Context.GetAuthenticationManager().SignOut();
        return HttpStatusCode.Unauthorized;
      });
      Get("/Error{error}{error_description}",  args => View["Error"]);
    }
  }}