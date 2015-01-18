//-----------------------------------------------------------------------
// <copyright file="IAuthServicesApi.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Web;
using Last.fm.API.Core;
using Last.fm.API.Core.Web;

namespace Last.fm.API.Auth
{
    [ServiceContract]
    internal interface IAuthServicesApi : IApiKeys
    {
        #region auth.getMobileSession

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="apiSig">api_sig (Required) : A Last.fm method signature. See authentication for more information.</param>
        /// <param name="username">username (Required) : The last.fm username.</param>
        /// <param name="password">password (Required) : The password in plain text.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "?method=auth.getMobileSession&api_key={apiKey}&username={username}&password={password}&api_sig={apiSig}")]
        [Obsolete]
        AuthSession GetMobileSession(string apiKey, string apiSig, string username, string password);

        #endregion

        #region auth.getToken

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="apiSig">api_sig (Required) : A Last.fm method signature. See authentication for more information.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "?method=auth.getToken&api_key={apiKey}&api_sig={apiSig}")]
        AuthToken GetToken(string apiKey, string apiSig);

        #endregion

        #region auth.getSession

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="apiSig">api_sig (Required) : A Last.fm method signature. See authentication for more information.</param>
        /// <param name="token">token (Required) : A 32-character ASCII hexadecimal MD5 hash returned by step 1 of the authentication process (following the granting of permissions to the application by the user)</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "?method=auth.getSession&api_key={apiKey}&api_sig={apiSig}&token={token}")]
        AuthSession GetSession(string apiKey, string apiSig, string token);

        #endregion
    }
}
