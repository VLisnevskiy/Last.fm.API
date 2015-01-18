//-----------------------------------------------------------------------
// <copyright file="AuthServicesClient.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Last.fm.API.Core;
using Last.fm.API.Core.Settings;

namespace Last.fm.API.Auth
{
    internal class AuthServicesClient : BaseLastFmClient<IAuthServicesApi>, IAuthServices
    {
        #region IAuthServices methods

        public AuthSession GetMobileSession(string password, string username)
        {
            username = username.ToLowerInvariant();
            string apiSig = BuildSig(SigMobileSession, MtN.Auth.MobileSession, password, username);
            var result =  Channel.GetMobileSession(ApiKey, apiSig, username, password);
            return result;
        }

        public AuthToken GetToken()
        {
            string apiSig = BuildSig(SigToken, MtN.Auth.Token);
            var result = Channel.GetToken(ApiKey, apiSig).SetUrl(ApiKey);
            return result;
        }

        public AuthSession GetSession(string token)
        {
            string apiSig = BuildSig(SigSession, MtN.Auth.Session, token);
            var result = Channel.GetSession(ApiKey, apiSig, token);
            return result;
        }

        #endregion

        #region IDisposable

        ~AuthServicesClient()
        {
            Dispose(false);
        }

        #endregion

        internal const string SigMobileSession = "api_key{0}method{1}password{2}username{3}{4}";

        internal const string SigSession = "api_key{0}method{1}token{2}{3}";

        internal const string SigToken = "api_key{0}method{1}{2}";

        #region Old implementation

        /*
        internal const string SigMobileSession = "api_key{0}authToken{1}method{2}rawtrueusername{3}{4}";
        
        internal const string SigSession = "api_key{0}method{1}rawtruetoken{2}{3}";

        internal const string SigToken = "api_key{0}method{1}rawtrue{2}";
        */

        #endregion
    }
}
