using System.Collections.Specialized;

namespace Nancy.OWin.Security.MSGraph.Util
{
  public interface IGraphAppConfig
  {
    string Tenant { get; }

    string AppId { get; }

    string AppIdUri { get; }

    string ReplyUrl { get; }

    string AppKey { get; }

    string Scopes { get; }
  }
  
  public interface IOpenIdAppConfig : IGraphAppConfig
  {
    string Authority { get; }

    string MetadataUri { get; }

    string PostLogoutRedirectUri { get; }

    string ResetPasswordUri { get; }

    string AccessDeniedUri { get; }

    string ErrorUri { get; }

    StringCollection Policies { get; }

    StringCollection Captions { get; }
  }
}
