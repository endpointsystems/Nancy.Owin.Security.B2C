# Nancy.OWin.Security.B2C

---

## Obsolete

This code is for `Nancy 2.0.0-clinteastwood`, which is at this point an ancient relic. Use at your own risk.

---

### Nancy authentication and operations against Azure AD B2C

The purpose of this library is to provide Nancy OWin support for authentication Microsoft Azure Active Directory B2C. 

#### How it works 

- When authenticating, you are going to use OpenID to connect and authenticate against your respective directory
- When performing other operations (accessing someone's O365 account, or reading what groups a user belongs to in the directory) you use graph operations. 

For step by step instructions on how to get started: https://endpointsystems.com/blog/introducing-nancy-owin-security-b2c

#### Azure Active Directory B2C

The most significant difference between Azure AD and Azure AD B2C is the extensible policy framework. Policies fully describe consumer identity experiences such as sign-up, sign-in, or profile editing. There are [built-in policies](https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-reference-policies) for getting started, as well as the ability to create custom policies via the [Identity Experience Framework](https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-overview-custom). 

Policies can include things like:

- using social media accounts (Facebook, Twitter, etc.) enterprise or local accounts for registration and access
- custom attributes for consumer data collection 
- [Multi-Factor Authentication](https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-reference-mfa)
- User profile editing or password resetting

Note: Graph API and MSGraph were originally intended for inclusion in this project; however, it appears that Graph API will eventually be superseded by MSGraph, and given the nature of Graph API operations, it appears that the better application for anything related to Graph API operations be in a separate application altogether. That said, here is some information on MS Graph, Graph API, and Azure Active Directory.

#### Graph API and MS Graph

[MS Graph](https://developer.microsoft.com/en-us/graph) is a REST API platform that allows developers to access the Office 365 suite. You'll use this for most development efforts revolving around Office 365 development.

![What's in the graph?](microsoft_graph.png)



While [Azure AD Graph API](https://msdn.microsoft.com/Library/Azure/Ad/Graph/howto/azure-ad-graph-api-operations-overview?f=255&MSPPError=-2147217396) is on its way towards general obsolescence, it is important to understand that it is the API to use if you want to interact with your Azure AD B2C tenant - not MS Graph. This tends to get a little confusing, so it's worth pointing out the differences. 

##### MS Graph Links

- [Graph Documentation](https://developer.microsoft.com/en-us/graph/docs/concepts/overview) 
- [Microsoft Graph samples on GitHub](https://github.com/search?q=aspnet+sample+user:microsoftgraph&type=Repositories)

##### Graph API Links

- [Azure AD B2C: Use the Azure AD Graph API](https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-devquickstarts-graph-dotnet)
- [Graph API Reference](https://msdn.microsoft.com/en-us/library/azure/ad/graph/api/api-catalog) 

#### Azure Active Directory

Authenticate against Azure AD using personal or work credentials. For more information:

- [Scopes, permissions, and consent in the Azure Active Directory 2.0 endpoint](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-v2-scopes) 
- [Azure Active Directory v2.0 and the OpenID Connect Protocol](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-v2-protocols-oidc)


#### Sample App

Included in this repo is a sample application using Nancy 2.0 and Owin, authenticating and performing customer an Azure AD B2C tenant. Others will follow suit as the project progresses. 

#### Project Status

Currently everything in the code revolves around Azure AD B2C. 

#### Acknowledgments

Much of the code in this library currently comes from the repositories listed below:

- [Active Directory B2C Advanced Policies](https://github.com/Azure-Samples/active-directory-b2c-advanced-policies)

- [Nancy.MSOwinSecurity from damianh](https://github.com/damianh/Nancy.MSOwinSecurity)

- https://github.com/AzureADQuickStarts/B2C-GraphAPI-DotNet

  ​
