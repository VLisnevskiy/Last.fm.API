//-----------------------------------------------------------------------
// <copyright file="IAuthServicesApi.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ServiceModel;
using System.ServiceModel.Web;
using Last.fm.API.Core;

namespace Last.fm.API.Auth
{
    [ServiceContract]
    internal interface IAuthServicesApi : IApiKeys
    {
        #region auth.getToken

        /// <summary>
        /// Fetch an unathorized request token for an API account.
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="apiSig">api_sig (Required) : A Last.fm method signature. See authentication for more information.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "?method=auth.getToken&api_key={apiKey}&api_sig={apiSig}")]
        AuthToken GetToken(string apiKey, string apiSig);

        #endregion

        #region auth.getSession

        /// <summary>
        /// Fetch a session key for a user.
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="apiSig">api_sig (Required) : A Last.fm method signature. See authentication for more information.</param>
        /// <param name="token">token (Required) : A 32-character ASCII hexadecimal MD5 hash returned by step 1 of the authentication process (following the granting of permissions to the application by the user)</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "?method=auth.getSession&api_key={apiKey}&api_sig={apiSig}&token={token}")]
        AuthSession GetSession(string apiKey, string apiSig, string token);

        #endregion
    }
}
