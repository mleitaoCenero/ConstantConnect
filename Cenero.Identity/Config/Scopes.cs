using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cenero.Identity.Config
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>
                {
                    StandardScopes.OpenId,
                    StandardScopes.ProfileAlwaysInclude,
                    StandardScopes.Address,
                    new Scope
                    {
                        Name = "constantconnectmanagement",
                        DisplayName = "ConstantConnect Management",
                        Description = "Allow the application to Manage Constant Connect on your behalf.",
                        Type = ScopeType.Resource,
                        Emphasize = true,
                        Claims = new List<ScopeClaim>()
                        {
                            new ScopeClaim("role")
                        },
                    },
                    new Scope
                    {
                        Name = "roles",
                        DisplayName = "Roles",
                        Description = "Allow the application to see your role(s).",
                        Type = ScopeType.Identity,
                        
                        Claims = new List<ScopeClaim>()
                        {
                            new ScopeClaim("role")
                        }
                    },
                    StandardScopes.OfflineAccess
                };
        }
    }
}