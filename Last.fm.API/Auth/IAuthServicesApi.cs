//-----------------------------------------------------------------------
// <copyright file="IAuthServicesApi.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Last.fm.API.Core;
using Last.fm.API.Core.Web;

namespace Last.fm.API.Auth
{
    [Service("Auth")]
    internal interface IAuthServicesApi : IApiKeys
    {
        #region auth.getMobileSession

        /// <summary>
        /// Create a web service session for a user. Used for authenticating a user when the password
        /// can be inputted by the user. Accepts email address as well, so please use the username supplied
        /// in the output. Only suitable for standalone mobile devices. See the authentication how-to for more.
        /// You must use HTTPS and POST in order to use this method.
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="apiSig">api_sig (Required) : A Last.fm method signature. See authentication for more information.</param>
        /// <param name="password">password (Required) : The password in plain text.</param>
        /// <param name="username">username (Required) : The last.fm username or email address.</param>
        /// <returns></returns>
        [WebMethod(Name = "auth.getMobileSession", Method = HttpMethod.POST)]
        AuthSession GetMobileSession([Parameter("api_key")] string apiKey, [Parameter("api_sig")] string apiSig, [Parameter("password")] string password, [Parameter("username")] string username);

        #endregion

        #region auth.getToken

        /// <summary>
        /// Fetch an unathorized request token for an API account.
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="apiSig">api_sig (Required) : A Last.fm method signature. See authentication for more information.</param>
        /// <returns></returns>
        [WebMethod(Name = "auth.getToken", Method = HttpMethod.GET)]
        AuthToken GetToken([Parameter("api_key")] string apiKey, [Parameter("api_sig")] string apiSig);

        #endregion

        #region auth.getSession

        /// <summary>
        /// Fetch a session key for a user.
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="apiSig">api_sig (Required) : A Last.fm method signature. See authentication for more information.</param>
        /// <param name="token">token (Required) : A 32-character ASCII hexadecimal MD5 hash returned by step 1 of the authentication process (following the granting of permissions to the application by the user)</param>
        /// <returns></returns>
        [WebMethod(Name = "auth.getSession", Method = HttpMethod.POST)]
        AuthSession GetSession([Parameter("api_key")] string apiKey, [Parameter("api_sig")] string apiSig, [Parameter("token")] string token);

        #endregion
    }
}
