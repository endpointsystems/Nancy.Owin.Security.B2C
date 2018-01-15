using Microsoft.Owin.Security.OpenIdConnect;
using Nancy.OWin.Security.B2C.Util;
using Owin;

namespace Nancy.OWin.Security.B2C
{
  /// <summary>
  /// OWin extension for adding B2C OpenID connection policies to the runtime.
  /// </summary>
  public static class B2COpenIdConnectExtensions
  {
    /// <summary>
    /// Register OpenId B2C policies against the OWin runtime.
    /// </summary>
    /// <remarks>
    /// The <seealso cref="IOpenIdAppConfig"/> configuration object accomodates for several policies to be 
    /// injected into the <seealso cref="OpenIdConnectAuthenticationMiddleware"/> 
    /// </remarks>
    /// <param name="app">The application context.</param>
    /// <param name="config">The configuration settings.</param>
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
