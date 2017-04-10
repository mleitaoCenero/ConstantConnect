using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Cenero.Identity.Config
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>(){
                new InMemoryUser
                {
                    Username ="Michael",
                    Password="secret",
                    Subject="3EB11A44-B95B-DC11-BE3C-000D9DDCDAF3",

                    Claims = new []
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "Michael"),
                        new Claim(Constants.ClaimTypes.FamilyName, "Leitao")
                    }

                }
            };
        }
    }
}