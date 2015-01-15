using Last.fm.API.ArtistServices;
using Last.fm.API.AuthServices;
using Last.fm.API.UserServices;

namespace Last.fm.API.BaseLastFm
{
    /// <summary>
    /// Holder for Last.fm web services
    /// </summary>
    public static class LastFmServicesHolder
    {
        #region Internal & Private Methods

        private static string _apiKey = "4930efce82e84fef13f6309659fe2bcd";

        private static string _apiSig = "b78261d1e86a65fe8f78abbd322681ac";

        /// <summary>
        /// WebServices ApiKey
        /// </summary>
        public static string ApiKey { get { return _apiKey; } }

        /// <summary>
        /// WebServices ApiSig
        /// </summary>
        public static string ApiSig { get { return _apiSig; } }

        /// <summary>
        /// Initialize ApiKey for current instance of web service
        /// </summary>
        /// <param name="apiKey">ApiKey</param>
        public static void InitializeServiceApiKey(string apiKey)
        {
            _apiKey = apiKey;
        }

        /// <summary>
        /// Initialize ApiSig for current instance of web service
        /// </summary>
        /// <param name="apiSig">ApiSig</param>
        public static void InitializeServiceApiSig(string apiSig)
        {
            _apiSig = apiSig;
        }
        
        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IUserServices CreateUserServicesClientProxy()
        {
            return new UserServicesClient(_apiKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public static IUserServices CreateUserServicesClientProxy(string apiKey)
        {
            _apiKey = apiKey;
            return new UserServicesClient(_apiKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IAuthServices CreateAuthServicesClientProxy()
        {
            return new AuthServicesClient(_apiKey, _apiSig);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="apiSig"></param>
        /// <returns></returns>
        public static IAuthServices CreateAuthServicesClientProxy(string apiKey, string apiSig)
        {
            return new AuthServicesClient(_apiKey = apiKey, _apiSig = apiSig);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="apiSig"></param>
        /// <returns></returns>
        public static IArtistServices CreateArtistServicesClientProxy(string apiKey, string apiSig)
        {
            return new ArtistServicesClient(_apiKey = apiKey, _apiSig = apiSig);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IArtistServices CreateArtistServicesClientProxy()
        {
            return new ArtistServicesClient(_apiKey, _apiSig);
        }

        #endregion
    }
}