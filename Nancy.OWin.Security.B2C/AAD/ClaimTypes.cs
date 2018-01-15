namespace Nancy.OWin.Security.MSGraph.AAD
{
  /// <summary>
  /// Claim types for Azure AD. 
  /// </summary>
  /// <remarks>It should be noted that these claim types do not apply to Azure AD B2C</remarks>
  /// <seealso href="https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-token-and-claims"/>
  public static class ClaimTypes
  {
    public const string AppId = "appid";
    /// <summary>
    /// The intended recipient of the token. The application that receives the token must verify that the audience value is correct and reject any tokens intended for a different audience. 
    /// </summary>
    public const string Audience = "aud";
    /// <summary>
    /// Indicates how the client was authenticated. For a public client, the value is 0. If client ID and client secret are used, the value is 1. 
    /// </summary>
    public const string ApplicationAuthenticationContext = "appidacr";
    /// <summary>
    /// Indicates how the subject was authenticated, as opposed to the client in the Application Authentication 
    /// Context Class Reference claim. A value of "0" indicates the end-user authentication did not meet the requirements of ISO/IEC 29115.
    /// </summary>
    public const string AuthenticationContext = "acr";
    /// <summary>
    /// Identifies how the subject of the token was authenticated. 
    /// </summary>
    public const string AuthenticationMethod = "amr";
    /// <summary>
    /// Provides the first or "given" name of the user, as set on the Azure AD user object. 
    /// </summary>
    public const string FirstName = "given_name";
    /// <summary>
    /// Provides object IDs that represent the subject's group memberships. These values are unique (see Object ID) 
    /// and can be safely used for managing access, such as enforcing authorization to access a resource. The groups 
    /// included in the groups claim are configured on a per-application basis, through the "groupMembershipClaims" property 
    /// of the application manifest. A value of null will exclude all groups, a value of "SecurityGroup" will include only 
    /// Active Directory Security Group memberships, and a value of "All" will include both Security Groups and 
    /// Office 365 Distribution Lists. 
    /// </summary>
    public const string Groups = "groups";
    /// <summary>
    /// Records the identity provider that authenticated the subject of the token. This value is identical to 
    /// the value of the Issuer claim unless the user account is in a different tenant than the issuer. 
    /// </summary>
    public const string IdentityProvider = "idp";
    /// <summary>
    /// Stores the time at which the token was issued. It is often used to measure token freshness. 
    /// </summary>
    public const string IssuedAt = "iat";
    /// <summary>
    /// dentifies the security token service (STS) that constructs and returns the token. In the tokens that Azure AD 
    /// returns, the issuer is sts.windows.net. The GUID in the Issuer claim value is the tenant ID of the Azure AD 
    /// directory. The tenant ID is an immutable and reliable identifier of the directory. 
    /// </summary>
    public const string Issuer = "iss";
    /// <summary>
    /// Provides the last name, surname, or family name of the user as defined in the Azure AD user object. 
    /// </summary>
    public const string LastName = "family_name";
    /// <summary>
    /// Provides a human readable value that identifies the subject of the token. This value is not guaranteed to 
    /// be unique within a tenant and is designed to be used only for display purposes. 
    /// </summary>
    public const string Name = "unique_name";
    /// <summary>
    /// Contains a unique identifier of an object in Azure AD. This value is immutable and cannot be reassigned 
    /// or reused. Use the object ID to identify an object in queries to Azure AD. 
    /// </summary>
    public const string ObjectId = "oid";
    /// <summary>
    /// Represents all application roles that the subject has been granted both directly and indirectly through 
    /// group membership and can be used to enforce role-based access control. Application roles are defined 
    /// on a per-application basis, through the <c>appRoles</c> property of the application manifest. The value 
    /// property of each application role is the value that appears in the roles claim. 
    /// </summary>
    public const string Roles = "roles";
    /// <summary>
    /// Indicates the impersonation permissions granted to the client application. The default permission is <c>user_impersonation</c>. 
    /// The owner of the secured resource can register additional values in Azure AD. 
    /// </summary>
    public const string Scope = "scp";
    /// <summary>
    /// Identifies the principal about which the token asserts information, such as the user of an application. This value is 
    /// immutable and cannot be reassigned or reused, so it can be used to perform authorization checks safely. Because the subject 
    /// is always present in the tokens the Azure AD issues, we recommended using this value in a general purpose authorization system. 
    /// </summary>
    public const string Subject = "sub";
    /// <summary>
    /// An immutable, non-reusable identifier that identifies the directory tenant that issued the token. You can use 
    /// this value to access tenant-specific directory resources in a multi-tenant application. For example, 
    /// you can use this value to identify the tenant in a call to the Graph API. 
    /// </summary>
    public const string TenantId = "tid";
    /// <summary>
    /// Defines the time interval within which a token is valid. Used with <see cref="NotBefore"/>.
    /// </summary>
    public const string NotOnOrAfter = "exp";
    /// <summary>
    /// Defines the time interval within which a token is valid. Used with <see cref="NotOnOrAfter"/>.
    /// </summary>
    public const string NotBefore = "nbf";
    /// <summary>
    /// Stores the version number of the token. 
    /// </summary>
    public const string Version = "ver";
    public const string UserPrincipalName = "upn";


  }
}
