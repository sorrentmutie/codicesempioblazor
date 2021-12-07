// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer.Models;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                //new IdentityResources.Profile(),
                new ProfiloConRuoliIdentityResource(),
                new IdentityResources.Email(),
                new IdentityResources.Phone()
                   };


        public static IEnumerable<ApiScope> Apis =>
            new ApiScope[]
            {
                new ApiScope("weatherapi", "weatherapi", userClaims: new[] { JwtClaimTypes.Role }),
                new ApiScope("magazzino"),
                new ApiScope("ordini")
            }; 

        public static IEnumerable<ApiResource> ApiScopes =>
            new ApiResource[]
            {
                new ApiResource("magazzino", "Magazzino"),
                new ApiResource("ordini", "Ordini"),
                new ApiResource("weatherapi", "Weather API",
                    userClaims: new[] { JwtClaimTypes.Role }) { Scopes = new [] {"weatherapi" } }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId ="myblazorapp",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedScopes = {"openid","profile", "email", "weatherapi"},
                    AllowedCorsOrigins = {"https://localhost:5001" },
                    Enabled = true,
                    RedirectUris =
                    {
                        "https://localhost:5001/authentication/login-callback"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:5001/"
                    }
                },
                new Client
                {
                    ClientId ="myblazorapp2",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedScopes = {"openid","profile", "email", "ordini", "weatherapi"},
                    AllowedCorsOrigins = {"https://localhost:5001" },
                    Enabled = true,
                    RedirectUris =
                    {
                        "https://localhost:5001/authentication/login-callback"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:5001/"
                    }
                }
            };
    }
}