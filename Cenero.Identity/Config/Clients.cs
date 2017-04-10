using ConstantConnect.Constants;
using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cenero.Identity.Config
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "Constant Connect Client",
                    Flow = Flows.Hybrid,
                    AllowAccessToAllScopes = true,
                    RequireConsent = false,
                    IdentityTokenLifetime = 300,
                    AccessTokenLifetime = 3600,
                    RedirectUris = new List<string>
                    {
                        Constants.ConstantConnectClient
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                         Constants.ConstantConnectClient
                    },
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret(Constants.ConstantConnectClientSecret.Sha256())
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        ConstantConnect.Constants.Constants.ConstantConnectAPI,
                        ConstantConnect.Constants.Constants.ConstantConnectClient,
                        ConstantConnect.Constants.Constants.ConstantConnectIdentity
                    }
                }
            };
        }
    }
}