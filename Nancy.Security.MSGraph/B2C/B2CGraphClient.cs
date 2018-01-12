using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Nancy.OWin.Security.MSGraph.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace Nancy.OWin.Security.MSGraph.B2C
{
  /// <summary>
  /// Graph API client for accessing the B2C AD back end.
  /// </summary>
  /// <seealso href="https://msdn.microsoft.com/Library/Azure/Ad/Graph/howto/azure-ad-graph-api-operations-overview?f=255&amp;MSPPError=-2147217396"/>
  /// <seealso href="https://github.com/AzureADQuickStarts/B2C-GraphAPI-DotNet"/>
  public class B2CGraphClient
  {
    private readonly IGraphAppConfig config;
    private readonly AuthenticationContext context;
    private readonly ClientCredential credential;
    public static string aadInstance = "https://login.microsoftonline.com/";
    public static string aadGraphResourceId = "https://graph.windows.net/";
    public static string aadGraphEndpoint = "https://graph.windows.net/";
    public static string aadGraphSuffix = "";
    public static string aadGraphVersion = "api-version=1.6";
    
    /// <summary>
    /// Initialize the graph client.
    /// </summary>
    /// <param name="graphConfig">The Graph API configuration items.</param>
    public B2CGraphClient(IGraphAppConfig graphConfig)
    {
      config = graphConfig;
      // The AuthenticationContext is ADAL's primary class, in which you indicate the direcotry to use.
      context = new AuthenticationContext("https://login.microsoftonline.com/" + config.Tenant);

      // The ClientCredential is where you pass in your client_id and client_secret, which are 
      // provided to Azure AD in order to receive an access_token using the app's identity.
      credential = new ClientCredential(config.AppId, config.AppKey);
    }
    /// <summary>
    /// Get a specified user.
    /// </summary>
    /// <remarks>You can use either the objectId or the UPN, but external users require the objectId.</remarks>
    /// <param name="objectId">The user objectId.</param>
    /// <returns>A dynamic JSON object containing the result.</returns>
    /// <seealso href="https://msdn.microsoft.com/en-us/library/azure/ad/graph/api/users-operations#GetAUser"/>
    public async Task<dynamic> GetUserByObjectId(string objectId)
    {
      return await SendGraphRequest("/users/" + objectId, HttpMethod.Get);
    }
    /// <summary>
    /// Gets the groups the user is a direct member of.
    /// </summary>
    /// <param name="objectId">The user objectId.</param>
    /// <returns>A dynamic JSON object containing the result.</returns>
    /// <seealso href="https://msdn.microsoft.com/en-us/library/azure/ad/graph/api/functions-and-actions#getMemberGroups"/>
    public async Task<dynamic> GetMemberGroups(string objectId)
    {
      return await SendGraphRequest($"/users/{objectId}/memberOf",HttpMethod.Get);
    }

    /// <summary>
    /// Check whether a specified user, group, contact or service principal is a member of a specified group. The operation is transitive.
    /// </summary>
    /// <param name="userId">The user, group, contact or service principal Id.</param>
    /// <param name="groupId">The group objectId to check against.</param>
    /// <returns>A dynamic JSON object containing the result.</returns>
    /// <seealso href="https://msdn.microsoft.com/en-us/library/azure/ad/graph/api/functions-and-actions#isMemberOf"/>
    public async Task<dynamic> IsMemberOf(string userId, string groupId)
    {
      return await SendGraphRequest("/isMemberOf", HttpMethod.Get, null,
        $"{{\"groupId\": \"{groupId}\",\"memberId\": \"{userId}\"}}");
    }

    /// <summary>
    /// Gets a collection of users. You can add OData query parameters to the request to filter, sort, and page the response. 
    /// </summary>
    /// <param name="filter">the OData query parameters.</param>
    /// <returns>The collection of users.</returns>
    /// <seealso href="https://msdn.microsoft.com/en-us/library/azure/ad/graph/api/users-operations#GetUsers"/>
    public async Task<dynamic> GetAllUsers(string filter)
    {
      return await SendGraphRequest("/users", HttpMethod.Get, filter);
    }

    /// <summary>
    /// Update a user's properties.
    /// </summary>
    /// <param name="objectId">The user's objectId.</param>
    /// <param name="json">The payload containing the property updates.</param>
    /// <returns>An empty confirmation indicating success, or an exception is thrown.</returns>
    /// <seealso href="https://msdn.microsoft.com/en-us/library/azure/ad/graph/api/users-operations#UpdateUser"/>
    public async Task<dynamic> UpdateUser(string objectId, string json)
    {
      return await SendGraphRequest("/users/" + objectId,new HttpMethod("PATCH"),null, json);
    }

    /// <summary>
    /// Deletes a user.
    /// </summary>
    /// <param name="objectId">The user objectId.</param>
    /// <returns>An empty payload confirming completion, or an exception is thrown.</returns>
    public async Task<dynamic> DeleteUser(string objectId)
    {
      return await SendGraphRequest("/users/" + objectId,HttpMethod.Delete);
    }


    private async Task<dynamic> SendGraphRequest(string api, HttpMethod method, string query = null, string json = null)
    {
      var result = await context.AcquireTokenAsync(aadGraphResourceId, credential);
      var http = new HttpClient();
      var url = aadGraphEndpoint + config.Tenant+ api + "?" + aadGraphVersion;
      if (!string.IsNullOrEmpty(query))
      {
        url += "&" + query;
      }

      var request = new HttpRequestMessage(method, url);
      if (json != null) request.Content = new StringContent(json, Encoding.UTF8, "application/json");
      request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
      var response = await http.SendAsync(request);

      if (!response.IsSuccessStatusCode)
      {
        string error = await response.Content.ReadAsStringAsync();
        object formatted = JsonConvert.DeserializeObject(error);
        throw new WebException("Error Calling the Graph API: \n" + JsonConvert.SerializeObject(formatted, Formatting.Indented));
      }

      var obj = await response.Content.ReadAsStringAsync();
      return JObject.Parse(obj);
    }

  }
}
