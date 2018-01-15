using System.Collections.Specialized;

namespace Nancy.OWin.Security.B2C.Util
{
  public interface IGraphAppConfig
  {
    /// <summary>
    /// Gets the Azure AD tenant name.
    /// </summary>
    string Tenant { get; }
    /// <summary>
    /// Gets the Azure AD app ID.
    /// </summary>
    string AppId { get; }
    /// <summary>
    /// Gets the Azure AD app reply URL.
    /// </summary>
    string ReplyUrl { get; }
    /// <summary>
    /// Gets the Azure AD app secret.
    /// </summary>
    string AppKey { get; }
    /// <summary>
    /// Gets the Azure AD application scopes. This can be set to null.
    /// </summary>
    string Scopes { get; }
  }

  public interface IOpenIdAppConfig : IGraphAppConfig
  {
    /// <summary>
    /// Gets the issuing autheority. This is optional.
    /// </summary>
    string Authority { get; }
    /// <summary>
    /// Gets the metadata URL for the OpenID data.
    /// </summary>
    string MetadataUri { get; }
    /// <summary>
    /// Gets the logout redirect URl. This is optional.
    /// </summary>
    string PostLogoutRedirectUri { get; }
    /// <summary>
    /// Gets the reset password URL. this is optional.
    /// </summary>
    string ResetPasswordUri { get; }
    /// <summary>
    /// Gets the access denied URL. This is optional.
    /// </summary>
    string AccessDeniedUri { get; }
    /// <summary>
    /// Gets the URL for errors. This is optional.
    /// </summary>
    string ErrorUri { get; }
    /// <summary>
    /// Gets a list of B2C policies implemented in the Azure AD B2C directory.
    /// </summary>
    StringCollection Policies { get; }
    /// <summary>
    /// Gets a list of captions for the B2C policies listed.
    /// </summary>
    StringCollection Captions { get; }
  }
}
