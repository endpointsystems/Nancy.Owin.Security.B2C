using Nancy.OWin.Security.MSGraph.Util;
using Owin;

namespace Nancy.OWin.Security.MSGraph.B2C
{
  public static class B2COpenIdConnectExtensions
  {
    public static void RegisterOpenIdConnectAuthPolicies(this IAppBuilder app, IOpenIdAppConfig config)
    {
      for (int index = config.Policies.Count - 1; index >= 0; --index)
      {
        var idConnectOptions = new B2COpenIdConnectOptions(config.Captions[index], config.Tenant, config.Policies[index], config.Scopes, 
          config.AppId, config.AppKey, config.MetadataUri, config.ReplyUrl, config.ResetPasswordUri, config.ErrorUri, config.AccessDeniedUri);
        app.UseOpenIdConnectAuthentication(idConnectOptions.Options);
      }
    }
  }}
