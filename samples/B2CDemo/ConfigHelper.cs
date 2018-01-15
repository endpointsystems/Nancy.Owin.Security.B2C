using System.Collections.Specialized;
using B2CDemo.Properties;
using Nancy.OWin.Security.B2C.Util;

namespace B2CDemo
{
    public class OpenIdConfigHelper : IOpenIdAppConfig
    {
      public string Tenant => Settings.Default.Tenant;

      public string AppId => Settings.Default.LoginAppId;

      public string AppIdUri => Settings.Default.LoginAppId;

      public string ReplyUrl => Settings.Default.ReplyUrl;

      public string AppKey => Settings.Default.LoginAppKey;

      public string Scopes => Settings.Default.LoginScopes;

      public string Authority => null;

      public string MetadataUri =>  Settings.Default.LoginMetadataUri;

      public string PostLogoutRedirectUri =>  Settings.Default.ReplyUrl;

      public string ResetPasswordUri =>  "/ResetPassword";

      public string AccessDeniedUri =>  "/AccessDenied";

      public string ErrorUri =>  "/Error?error={0}&error_description={1}";

      public StringCollection Policies => Settings.Default.LoginPolicies;
        
      public StringCollection Captions => Settings.Default.LoginCaptions;
        
  }

  public class GraphConfigHelper: IGraphAppConfig
  {
    public string Tenant => Settings.Default.Tenant;
    public string AppId => Settings.Default.GraphAppId;
    public string AppIdUri => null;
    public string ReplyUrl => Settings.Default.ReplyUrl;
    public string AppKey => Settings.Default.GraphAppKey;
    public string Scopes => null;
  }
}