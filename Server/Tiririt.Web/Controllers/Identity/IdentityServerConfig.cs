using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Tiririt.Web.Controllers.Identity
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                //new ApiResource("api1", "My API #1")
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            };


        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // client credentials flow client
                //new Client
                //{
                //    ClientId = "client",
                //    ClientName = "Client Credentials Client",

                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                //    AllowedScopes = { "api1" }
                //},

                // MVC client using code flow + pkce
                //new Client
                //{
                //    ClientId = "mvc",
                //    ClientName = "MVC Client",

                //    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                //    RequirePkce = true,
                //    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                //    RedirectUris = { "http://localhost:5003/signin-oidc" },
                //    FrontChannelLogoutUri = "http://localhost:5003/signout-oidc",
                //    PostLogoutRedirectUris = { "http://localhost:5003/signout-callback-oidc" },

                //    AllowOfflineAccess = true,
                //    AllowedScopes = { "openid", "profile", "api1" }
                //},

                // SPA client using code flow + pkce
                new Client
                {
                    ClientId = "tiririt",
                    ClientName = "Tiririt Client",
                    ClientUri = "http://localhost:4200",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = true,
                    RequireConsent = false,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    

                    RedirectUris =
                    {
                        "http://localhost:4200/auth-callback",
                        "http://localhost:4200/callback.html"
                    },

                        //"http://localhost:4200/callback.html",
                        //"http://localhost:4200/silent.html",
                        //"http://localhost:4200/popup.html",

                    PostLogoutRedirectUris = { "http://localhost:4200/index.html" },
                    AllowedCorsOrigins = { "http://localhost:4200" },

                    AllowedScopes = { 
                        IdentityServerConstants.StandardScopes.OpenId, 
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.LocalApi.ScopeName                        
                    },
                    //AllowAccessTokensViaBrowser = true
                }
            };
    }
}
