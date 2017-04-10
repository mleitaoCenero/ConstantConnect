using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.IdentityModel.Tokens;
using System.Collections.Generic;
using IdentityServer3.AccessTokenValidation;

[assembly: OwinStartup(typeof(ConstantConnect.API.Startup))]

namespace ConstantConnect.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseIdentityServerBearerTokenAuthentication(
                new IdentityServerBearerTokenAuthenticationOptions
                {
                    Authority = Constants.Constants.ConstantConnectIdentity,
                    RequiredScopes = new[] { "constantconnectmanagement" }
                });


            var config = WebApiConfig.Register();

            app.UseWebApi(config);
        }
    }
}
