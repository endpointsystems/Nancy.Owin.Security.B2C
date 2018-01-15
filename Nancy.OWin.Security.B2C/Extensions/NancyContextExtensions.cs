using System;
using System.Collections.Generic;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Nancy.OWin.Security.B2C.Extensions
{
  /// <summary>
  /// This <seealso cref="NancyContext"/> extension pulls the <seealso cref="IAuthenticationManager"/> out of the OWin middleware. 
  /// </summary>
  /// <seealso href="https://github.com/damianh/Nancy.MSOwinSecurity"/>
  public static class NancyContextExtensions
  {
    public static IAuthenticationManager GetAuthenticationManager(this NancyContext context, bool throwOnNull = false)
    {
      context.Items.TryGetValue("OWIN_REQUEST_ENVIRONMENT", out var obj);
      var environment = obj as IDictionary<string, object>;
      if (environment == null & throwOnNull)
        throw new InvalidOperationException("OWIN environment not found");
      return environment == null ? null : new OwinContext(environment).Authentication;
    }
  }}
