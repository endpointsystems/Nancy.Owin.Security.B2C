using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OpenIdConnect;

namespace Nancy.OWin.Security.B2C
{

  public class B2COpenIdConnectOptions
  {
    public OpenIdConnectAuthenticationOptions Options { get; }

    public B2COpenIdConnectOptions(string caption, string tenant, string policy, string scope, string clientId, string clientSecret, string metadataUri, string redirectUri, string resetPasswordUri, string errorUri, string accessDeniedUri, TokenValidationParameters validation = null)
    {
      OpenIdConnectAuthenticationOptions authenticationOptions = new OpenIdConnectAuthenticationOptions
      {
        Notifications = GetNotifications(policy, resetPasswordUri, accessDeniedUri, errorUri)
      };
      TokenValidationParameters validationParameters = validation ?? new TokenValidationParameters()
      {
        SaveSigninToken = true
      };
      authenticationOptions.TokenValidationParameters = validationParameters;
      authenticationOptions.UseTokenLifetime = true;
      authenticationOptions.Caption = caption;
      authenticationOptions.AuthenticationType = policy;
      authenticationOptions.Scope = scope;
      authenticationOptions.ResponseType = "id_token";
      authenticationOptions.MetadataAddress = string.Format(metadataUri, tenant, policy);
      authenticationOptions.ClientId = clientId;
      authenticationOptions.ClientSecret = clientSecret;
      authenticationOptions.RedirectUri = redirectUri;
      authenticationOptions.PostLogoutRedirectUri = redirectUri;
      Options = authenticationOptions;
    }
    /// <summary>
    /// Configure the notification events coming from the OpenID B2C APIs. 
    /// </summary>
    /// <param name="policy">The B2C policy in use.</param>
    /// <param name="resetPasswordUri">The URL to redirect to in the event of a password reset.</param>
    /// <param name="accessDeniedUri">The URL to redirect to in the event of access being denied.</param>
    /// <param name="errorUri">The URL to redirect to in the event of an error.</param>
    /// <returns>The <see cref="OpenIdConnectAuthenticationNotifications"/> used as part of the <see cref="OpenIdConnectAuthenticationOptions"/></returns>
    private OpenIdConnectAuthenticationNotifications GetNotifications(string policy, string resetPasswordUri, string accessDeniedUri, string errorUri)
    {
      return new OpenIdConnectAuthenticationNotifications()
      {
        AuthenticationFailed = context =>
        {
          context.HandleResponse();
          switch (context.ProtocolMessage.Error)
          {
            case "access_denied":
              if (context.ProtocolMessage.ErrorDescription.StartsWith("AADB2C90118"))
              {
                context.Response.Redirect(resetPasswordUri);
                break;
              }
              if (context.ProtocolMessage.ErrorDescription.StartsWith("AADB2C90091"))
              {
                context.Response.Redirect(accessDeniedUri);
                break;
              }
              goto default;
            default:
              context.Response.Redirect(string.Format(errorUri, context.ProtocolMessage.Error, context.ProtocolMessage.ErrorDescription));
              break;
          }
          return (Task)Task.FromResult(0);
        },
        RedirectToIdentityProvider = context =>
        {
          string[] parts = context.ProtocolMessage.IssuerAddress.Split('?');
          context.ProtocolMessage.IssuerAddress = parts[0];
          if (parts.Length > 1)
            context.ProtocolMessage.Parameters.Add("p", policy);
          return Task.FromResult(0);
        },
        SecurityTokenValidated = context =>
        {
          Trace.WriteLine($"{DateTime.Now} B2C returned JWT : {context.ProtocolMessage.IdToken}");
          return (Task)Task.FromResult(0);
        }
      };
    }

    public static string ClientAuthToken(List<Claim> claims, string issuer, string audience, string clientSecret)
    {
      if (string.IsNullOrWhiteSpace(issuer))
        throw new ArgumentNullException(nameof(issuer));
      if (string.IsNullOrWhiteSpace(audience))
        throw new ArgumentNullException(nameof(audience));
      if (string.IsNullOrWhiteSpace(clientSecret))
        throw new ArgumentNullException(nameof(clientSecret));
      JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
      SigningCredentials signingCredentials = new SigningCredentials(new InMemorySymmetricSecurityKey(Encoding.UTF8.GetBytes(clientSecret)), "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256", "http://www.w3.org/2001/04/xmlenc#sha256");
      SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
      {
        Subject = new ClaimsIdentity(claims),
        Lifetime = new Lifetime(DateTime.Now, DateTime.Now.AddDays(1.0)),
        SigningCredentials = signingCredentials,
        AppliesToAddress = audience,
        TokenIssuerName = issuer
      };
      JwtSecurityToken token = (JwtSecurityToken)securityTokenHandler.CreateToken(tokenDescriptor);
      return securityTokenHandler.WriteToken(token);
    }
  }
}
