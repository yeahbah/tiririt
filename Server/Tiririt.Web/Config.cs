using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Tiririt.Web
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("TiriritApi", "Tiririt Api")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                 new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets = {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes = { "TiriritApi" }
                },
                new Client
                {
                    ClientId = "TiriritMvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    RequireConsent = false,
                    RequirePkce = true,
                    RedirectUris = { "https://localhost/tiriritmvc/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost/tiriritmvc/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "TiriritApi"
                    }
                }
            };
    }
}
