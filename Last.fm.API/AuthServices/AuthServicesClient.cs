using Last.fm.API.BaseLastFm;

namespace Last.fm.API.AuthServices
{
    internal class AuthServicesClient : BaseLastFmClient<IAuthServicesApi>, IAuthServices
    {
        public AuthServicesClient(string apiKey, string apiSig)
            : base(apiKey, apiSig)
        {
        }
        
        #region IAuthServices methods

        public AuthSession GetMobileSession(string password, string username)
        {
            username = username.ToLowerInvariant();
            string authToken = GetAuthToken(password, username);
            string apiSig = BuildSig(SigMobileSession, authToken, MtN.Auth.MobileSession, username);
            var result = Invoke(() => Channel.GetMobileSession(ApiKey, apiSig, authToken, username));
            return result;
        }

        public AuthToken GetToken()
        {
            string apiSig = BuildSig(SigToken, MtN.Auth.Token);
            var result = Invoke(() => Channel.GetToken(ApiKey, apiSig)).SetUrl(ApiKey);
            return result;
        }

        public AuthSession GetSession(string token)
        {
            string apiSig = BuildSig(SigSession, MtN.Auth.Session, token);
            var result = Invoke(() => Channel.GetSession(ApiKey, apiSig, token));
            return result;
        }

        #endregion

        #region IDisposable

        ~AuthServicesClient()
        {
            Dispose(false);
        }

        #endregion
        
        internal const string SigMobileSession = "api_key{0}authToken{1}method{2}rawtrueusername{3}{4}";
        
        internal const string SigSession = "api_key{0}method{1}rawtruetoken{2}{3}";

        internal const string SigToken = "api_key{0}method{1}rawtrue{2}";
    }
}
