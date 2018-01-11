# Nancy.OWin.Security.MSGraph

### Nancy authentication and operations against Azure AD, Azure AD B2C, Graph API and MS Graph

The purpose of this library is to provide Nancy OWin support for authentication and other graph-related operations against Microsoft Azure's many graph and directory offerings. 

##### Supported Artifacts

- [Microsoft Azure Active Directory (Azure AD)](https://docs.microsoft.com/en-us/azure/active-directory/)
- [Microsoft Azure Active Directory Business-to-Consumer (Azure AD B2C)](https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-overview) 
- [Microsoft Graph (MS Graph)](https://developer.microsoft.com/en-us/graph)
- [Azure Active Directory Graph API](https://developer.microsoft.com/en-us/graph) 

#### How it works 

If you're unfamiliar with these technologies, or confused on which one you use for what scenario, it works like this: 

- When authenticating, you are going to use OpenID to connect and authenticate against your respective directory
-  When performing other operations (accessing someone's O365 account, or reading what groups a user belongs to in the directory) you use graph operations. 

#### Graph API and MS Graph

[MS Graph](https://developer.microsoft.com/en-us/graph) is a REST API platform that allows developers to access the Office 365 suite. You'll use this for most development efforts revolving around Office 365 development.

![What's in the graph?](microsoft_graph.png)



While Graph API is on its way towards general obsolescence, it is important to understand that it is the API to use if you want to interact with your Azure AD B2C tenant - not MS Graph. This tends to get a little confusing, so it's worth pointing out the differences. 

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
- ​

#### Sample App

Included in this repo is a sample application using Nancy 2.0 and Owin, authenticating and performing options against an Azure AD B2C tenant. Others will follow suit as the project progresses

#### Project Status

Currently everything in the code revolves around a B2C scenario I've been working on. Now that the B2C code is where I need it, Graph API and MS Graph efforts will follow shortly. 