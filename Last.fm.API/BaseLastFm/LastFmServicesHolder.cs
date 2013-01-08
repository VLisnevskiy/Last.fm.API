using System.ServiceModel;
using Last.fm.API.UserServices;

namespace Last.fm.API.BaseLastFm
{
    public static class LastFmServicesHolder
    {
        #region Internal & Private Methods

        private static string _apiKey = "4930efce82e84fef13f6309659fe2bcd";

        public static string ApiKey { get { return _apiKey; } }

        public static void InitializeServiceApi(string apiKey)
        {
            _apiKey = apiKey;
        }

        internal static T CreateChannel<T>()
        {
            return new LastFmChannelFactory<T>(new WebHttpBinding()).CreateChannel();
        }

        #endregion

        #region Public Methods

        public static IUserServices CreateUserServicesClientProxy()
        {
            return new UserServicesClient(_apiKey);
        }

        public static IUserServices CreateUserServicesClientProxy(string apiKey)
        {
            _apiKey = apiKey;
            return new UserServicesClient(_apiKey);
        }

        #endregion
    }
}