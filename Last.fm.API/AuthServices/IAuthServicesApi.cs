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
            UriTemplate = "?method=auth.getMobileSession&raw=true&api_key={apiKey}&password={password}&api_sig={apiSig}&username={username}")]
        XmlDocument GetMobileSession(string apiKey, string apiSig, string password, string username);

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
            UriTemplate = "?method=auth.getToken&raw=true&api_key={apiKey}&api_sig={apiSig}")]
        XmlDocument GetToken(string apiKey, string apiSig);

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
            UriTemplate = "?method=auth.getSession&raw=true&api_key={apiKey}&api_sig={apiSig}&token={token}")]
        XmlDocument GetSession(string apiKey, string apiSig, string token);

        #endregion
    }


}
