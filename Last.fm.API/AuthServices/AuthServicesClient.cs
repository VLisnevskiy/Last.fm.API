using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Last.fm.API.BaseLastFm;

namespace Last.fm.API.AuthServices
{
    class AuthServicesClient : BaseLastFmClient<IAuthServicesApi>, IAuthServices
    {
        public AuthServicesClient(string apiKey, string apiSig)
            : base(apiKey, apiSig)
        {
        }

        #region IAuthServices methods

        public XmlDocument GetMobileSession(string password, string username)
        {
            var result = BaseInvoke(() => Channel.GetMobileSession(ApiKey, ApiSig, password, username));
            return result;
        }

        public XmlDocument GetToken()
        {
            var result = BaseInvoke(() => Channel.GetToken(ApiKey, ApiSig));
            return result;
        }

        public XmlDocument GetSession(string token)
        {
            var result = BaseInvoke(() => Channel.GetSession(ApiKey, ApiSig, token));
            return result;
        }

        #endregion

        #region IDisposable

        ~AuthServicesClient()
        {
            Dispose(false);
        }

        #endregion
    }
}
