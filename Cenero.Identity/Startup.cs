using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;
using Cenero.Identity.Config;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.Core.Services.Default;
using Cenero.Identity.Services;
using Serilog;
using IdentityServer3.Core.Services.InMemory;
using IdentityServer3.Core.Services;
using ConstantConnect.Constants;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(Cenero.Identity.Startup))]

namespace Cenero.Identity
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/identity", idsrvApp =>
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Trace()
                    .CreateLogger();

                var corsPolicyService = new DefaultCorsPolicyService()
                {
                    AllowAll = true
                };

                var defaultViewServiceOptions = new DefaultViewServiceOptions();
                defaultViewServiceOptions.Stylesheets.Add("/Content/Site.css");
                defaultViewServiceOptions.CacheViews = false;

                var idServerServiceFactory = new IdentityServerServiceFactory()
                                .UseInMemoryClients(Clients.Get())
                                .UseInMemoryScopes(Scopes.Get());

                idServerServiceFactory.CorsPolicyService = new
                    Registration<IdentityServer3.Core.Services.ICorsPolicyService>(corsPolicyService);

                idServerServiceFactory.ConfigureDefaultViewService(defaultViewServiceOptions);

                // use custom UserService
                var userService = new UserService();
                idServerServiceFactory.UserService = new Registration<IUserService>(resolver => userService);

               

                var options = new IdentityServerOptions
                {
                    Factory = idServerServiceFactory,
                    SiteName = "Cenero LLC Security Service",
                    SigningCertificate = LoadCertificate(),
                    IssuerUri = Constants.ConstantConnectIdentityIssuerUri,
                    PublicOrigin = Constants.ConstantConnectIdentityOrgin,
                    AuthenticationOptions = new AuthenticationOptions()
                    {
                        EnablePostSignOutAutoRedirect = true,
                        //LoginPageLinks = new List<LoginPageLink>()
                        //{
                        //    new LoginPageLink()
                        //    {
                        //        Type= "createaccount",
                        //        Text = "Create a new account",
                        //        Href = "~/createuseraccount"
                        //    }
                        //},
                        //IdentityProviders = ConfigureAdditionalIdProviders
                    },
                    CspOptions = new CspOptions()
                    {
                        Enabled = false
                        // once available, leave Enabled at true and use:
                        // FrameSrc = "https://localhost:44318 https://localhost:44316"
                        // or
                        // FrameSrc = "*" for all URI's.
                    }
                };

                

                idsrvApp.UseIdentityServer(options);
                
            });
        }
        private X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\certificates\Cenero.pfx",
                AppDomain.CurrentDomain.BaseDirectory), "Cenero2587");
        }
    }
}
