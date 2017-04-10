using IdentityServer3.Core.Services.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;
using System.Threading.Tasks;
using Cenero.Repository;
using IdentityServer3.Core;
using System.Security.Claims;
using IdentityServer3.Core.Extensions;
using Cenero.Repository.Entities;

namespace Cenero.Identity.Services
{
    public class UserService : UserServiceBase
    {
        #region Constructor
        public UserService()
        {

        }
        #endregion

        public override Task AuthenticateLocalAsync(IdentityServer3.Core.Models.LocalAuthenticationContext context)
        {
            using (var userRepository = new UserRepository())
            {
                // get user from repository
                var user = userRepository.GetUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.AuthenticateResult = new AuthenticateResult("Invalid credentials");
                    return Task.FromResult(0);
                }

                context.AuthenticateResult = new AuthenticateResult(
                    user.Subject,
                    user.UserClaims.First(c => c.ClaimType == Constants.ClaimTypes.GivenName).ClaimValue);

                return Task.FromResult(0);
            }
        }

        public override Task GetProfileDataAsync(IdentityServer3.Core.Models.ProfileDataRequestContext context)
        {
            using (var userRepository = new UserRepository())
            {
                // find the user
                var user = userRepository.GetUser(context.Subject.GetSubjectId());

                // add subject as claim
                var claims = new List<Claim>
                {
                    new Claim(Constants.ClaimTypes.Subject, user.Subject),
                };

                // add the other UserClaims
                claims.AddRange(user.UserClaims.Select<UserClaim, Claim>(
                    uc => new Claim(uc.ClaimType, uc.ClaimValue)));

                // only return the requested claims
                if (!context.AllClaimsRequested)
                {
                    claims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                }

                // set the issued claims - these are the ones that were requested, if available
                context.IssuedClaims = claims;

                return Task.FromResult(0);
            }
        }

        public override Task IsActiveAsync(IdentityServer3.Core.Models.IsActiveContext context)
        {
            using (var userRepository = new UserRepository())
            {
                if (context.Subject == null)
                {
                    throw new ArgumentNullException("subject");
                }

                var user = userRepository.GetUser(context.Subject.GetSubjectId());

                // set whether or not the user is active
                context.IsActive = (user != null) && user.IsActive;

                return Task.FromResult(0);
            }
        }

        public override Task PostAuthenticateAsync(PostAuthenticationContext context)
        {
            // we're logged in to identity server - but it might be that the application
            // requires 2FA.  

            // if we don't require 2FA, return & continue
            var twoFactorRequired = context.SignInMessage.AcrValues.Any(v => v == "2fa");
            if (!twoFactorRequired)
            {
                return Task.FromResult(0);
            }

            // we require 2FA
            using (var twoFactorTokenService = new TwoFactorTokenService())
            {
                if (twoFactorTokenService.HasVerifiedTwoFactorCode(context.AuthenticateResult.User.GetSubjectId()))
                {
                    return Task.FromResult(0);
                }
                else
                {
                    // the user hasn't inputted a (valid) 2FA code.  Generate one, and redirect
                    twoFactorTokenService.GenerateTwoFactorCodeFor(context.AuthenticateResult.User.GetSubjectId());

                    context.AuthenticateResult =
                         new AuthenticateResult("~/twofactorauthentication", context.AuthenticateResult.User.GetSubjectId(),
                             context.AuthenticateResult.User.GetName(), context.AuthenticateResult.User.Claims);
                    return Task.FromResult(0);
                }
            }
        }
    }
}