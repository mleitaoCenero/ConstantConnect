using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace ConstantConnect.API.Helpers
{
    public static class TokenIdentityHelper
    {
        public static string[] GetIdFromToken()
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;

            if (identity == null)
                return null;

            var issuerFromIdentity = identity.FindFirst("iss");
            var subFromIdentity = identity.FindFirst("sub");

            if (issuerFromIdentity == null | subFromIdentity == null)
                return null;

            return new string[] { issuerFromIdentity.Value, subFromIdentity.Value };
        }
    }
}