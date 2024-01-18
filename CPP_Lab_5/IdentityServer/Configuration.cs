using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System.Collections.Immutable;

namespace IdentityServer;


public static class Configuration
{
    public static ImmutableArray<IdentityResource> IdentityResources { get; } =
    [
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResource("extended_profile", new[]
        {
            "name",
            "phone_number",
            "email",
            "full_name"
        })
    ];


    public static ImmutableArray<Client> Clients { get; } =
    [
        new()
        {
            ClientId = "MainWebApp",
            ClientSecrets =
            {
                new("MainWebApp".Sha256())
            },
            AllowedGrantTypes = GrantTypes.Code,
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "extended_profile"
            },
            RedirectUris =
            {
                "http://localhost:5002/signin-oidc"
            },
            PostLogoutRedirectUris =
            {
                "http://localhost:5002/signout-callback-oidc"
            }
        }
    ];
}