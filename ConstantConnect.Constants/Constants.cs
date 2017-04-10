using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Constants
{
    public class Constants
    {
#if DEBUG
        public const string ConstantConnectAPI = "https://localhost:44310/";
        public const string ConstantConnectClient = "https://localhost:44399/";
        public const string ConstantConnectIdentityOrgin = "https://localhost:44351";
#else
        public const string ConstantConnectAPI = "https://api.cenero.com";
        public const string ConstantConnectClient = "https://client.cenero.com";
        public const string ConstantConnectIdentityOrgin = "https://identity.cenero.com";
#endif

        public const string ConstantConnectIdentityIssuerUri = "https://constantconnectidserver/embedded";

        public const string ConstantConnectIdentity = ConstantConnectIdentityOrgin + "/identity";
        public const string ConstantConnectIdentityToken = ConstantConnectIdentity + "/connect/token";
        public const string ConstantConnectIdentityAuthorize = ConstantConnectIdentity + "/connect/authorize";
        public const string ConstantConnectIdentityUserInfo = ConstantConnectIdentity + "/connect/userinfo";
        public const string ConstantConnectClientSecret = "!(R.6j:jrqD@ZgAMW5?W)@k";

        //public const string CeneroFileStore = @"\\TARDIS\"
    }
}
