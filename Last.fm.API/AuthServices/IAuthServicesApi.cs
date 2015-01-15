using System.ServiceModel;
using System.ServiceModel.Web;
using System.Xml;
using Last.fm.API.BaseLastFm;

namespace Last.fm.API.AuthServices
{
    [ServiceContract]
    [XmlSerializerFormat]
    internal interface IAuthServicesApi : IApiKeys
    {
        #region auth.getMobileSession

        /*
         * password (Required) : The password in plain text.
         * username (Required) : The last.fm username.
         * api_key (Required) : A Last.fm API key.
         * 
         * api_sig (Required) : A Last.fm method signature. See authentication for more information.
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=auth.getMobileSession&api_key={apiKey}&authToken={authToken}&username={username}&api_sig={apiSig}")]
        AuthSession GetMobileSession(string apiKey, string apiSig, string authToken, string username);

        #endregion

        #region auth.getToken

        /*
         * api_key (Required) : A Last.fm API key.
         * 
         * api_sig (Required) : A Last.fm method signature. See authentication for more information.
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=auth.getToken&api_key={apiKey}&api_sig={apiSig}")]
        AuthToken GetToken(string apiKey, string apiSig);

        #endregion

        #region auth.getSession

        /*
         * token (Required) : A 32-character ASCII hexadecimal MD5 hash returned by step 1 of the authentication process (following the granting of permissions to the application by the user)
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         * api_sig (Required) : A Last.fm method signature. See authentication for more information.
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=auth.getSession&api_key={apiKey}&api_sig={apiSig}&token={token}")]
        AuthSession GetSession(string apiKey, string apiSig, string token);

        #endregion
    }
}
