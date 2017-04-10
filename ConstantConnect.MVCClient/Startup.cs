using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OpenIdConnect;
using ConstantConnect.MVCClient.Helpers;
using System.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Web.Helpers;
using Microsoft.Owin.Security.Cookies;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json.Linq;
using System.Linq;
using IdentityModel.Client;

[assembly: OwinStartup(typeof(ConstantConnect.MVCClient.Startup))]

namespace ConstantConnect.MVCClient
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();


            AntiForgeryConfig.UniqueClaimTypeIdentifier = IdentityModel.JwtClaimTypes.Name;

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "Cookies",
                ExpireTimeSpan = new TimeSpan(0, 120, 0),
                SlidingExpiration = true
            });


            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "mvc",
                Authority = Constants.Constants.ConstantConnectIdentity,
                RedirectUri = Constants.Constants.ConstantConnectClient,
                UseTokenLifetime = false,
                SignInAsAuthenticationType = "Cookies",
                ResponseType="code id_token token",
                Scope= "openid profile roles address constantconnectmanagement offline_access",

                Notifications = new OpenIdConnectAuthenticationNotifications()
                {
                    SecurityTokenValidated = async n =>
                    {
                        var givenNameClaim = n.AuthenticationTicket
                            .Identity.FindFirst(IdentityModel.JwtClaimTypes.GivenName);

                        var familyNameClaim = n.AuthenticationTicket
                            .Identity.FindFirst(IdentityModel.JwtClaimTypes.FamilyName);

                        var subClaim = n.AuthenticationTicket
                            .Identity.FindFirst(IdentityModel.JwtClaimTypes.Subject);

                        var roleClaim = n.AuthenticationTicket
                            .Identity.FindFirst(IdentityModel.JwtClaimTypes.Role);

                        var nameClaim = new Claim(IdentityModel.JwtClaimTypes.Name,
                                    Constants.Constants.ConstantConnectIdentityIssuerUri + subClaim.Value);

                        var newClaimsIdentity = new ClaimsIdentity(
                           n.AuthenticationTicket.Identity.AuthenticationType,
                           IdentityModel.JwtClaimTypes.Name,
                           IdentityModel.JwtClaimTypes.Role);

                        if (nameClaim != null)
                        {
                            newClaimsIdentity.AddClaim(nameClaim);
                        }

                        if (givenNameClaim != null)
                        {
                            newClaimsIdentity.AddClaim(givenNameClaim);
                        }

                        if (familyNameClaim != null)
                        {
                            newClaimsIdentity.AddClaim(familyNameClaim);
                        }

                        if (roleClaim != null)
                        {
                            newClaimsIdentity.AddClaim(roleClaim);
                        }

                        var tokenClientForRefreshToken = new TokenClient(
                                   Constants.Constants.ConstantConnectIdentityToken,
                                   "mvc",
                                   Constants.Constants.ConstantConnectClientSecret);

                        var refreshResponse = await
                            tokenClientForRefreshToken.RequestAuthorizationCodeAsync(
                            n.ProtocolMessage.Code,
                            Constants.Constants.ConstantConnectClient);

                        var expirationDateAsRoundtripString
                            = DateTime.SpecifyKind(DateTime.UtcNow.AddSeconds(refreshResponse.ExpiresIn)
                            , DateTimeKind.Utc).ToString("o");


                        newClaimsIdentity.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
                        newClaimsIdentity.AddClaim(new Claim("refresh_token", refreshResponse.RefreshToken));
                        newClaimsIdentity.AddClaim(new Claim("access_token", refreshResponse.AccessToken));
                        newClaimsIdentity.AddClaim(new Claim("expires_at", expirationDateAsRoundtripString));

                        // create a new authentication ticket, overwriting the old one.
                        n.AuthenticationTicket = new AuthenticationTicket(
                                                 newClaimsIdentity,
                                                 n.AuthenticationTicket.Properties);
                    },
                    RedirectToIdentityProvider = async n =>
                    {
                        // get id token to add as id token hint
                        if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.LogoutRequest)
                        {
                            var identityTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token");

                            if (identityTokenHint != null)
                            {
                                n.ProtocolMessage.IdTokenHint = identityTokenHint.Value;
                            }
                        }
                        else if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.AuthenticationRequest)
                        {
                            string existingAcrValues = null;
                            //if (n.ProtocolMessage.Parameters.TryGetValue("acr_values", out existingAcrValues))
                            //{     
                            //    // add "2fa" - acr_values are separated by a space
                            //    n.ProtocolMessage.Parameters["acr_values"] = existingAcrValues + " 2fa";
                            //}

                            //n.ProtocolMessage.Parameters["acr_values"] = "2fa";
                        }
                    }
                }
            });
        }
    }
}
