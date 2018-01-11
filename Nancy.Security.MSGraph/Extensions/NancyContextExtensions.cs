using System;
using System.Collections.Generic;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Nancy.OWin.Security.MSGraph.Extensions
{
  public static class NancyContextExtensions
  {
    public static IAuthenticationManager GetAuthenticationManager(this NancyContext context, bool throwOnNull = false)
    {
      object obj;
      context.Items.TryGetValue("OWIN_REQUEST_ENVIRONMENT", out obj);
      IDictionary<string, object> environment = obj as IDictionary<string, object>;
      if (environment == null & throwOnNull)
        throw new InvalidOperationException("OWIN environment not found");
      if (environment == null)
        return (IAuthenticationManager) null;
      return new OwinContext(environment).Authentication;
    }
  }}
