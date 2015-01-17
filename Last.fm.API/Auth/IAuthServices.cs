//-----------------------------------------------------------------------
// <copyright file="IAuthServices.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Last.fm.API.BaseLastFm;
using Last.fm.API.Core;

namespace Last.fm.API.Auth
{
    /// <summary>
    /// Set of API Methods for Auth section
    /// </summary>
    public interface IAuthServices : IApiKeys, IDisposable
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
        /// <summary>
        /// auth.getMobileSession
        /// </summary>
        /// <param name="password"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        AuthSession GetMobileSession(string password, string username);

        #endregion

        #region auth.getToken

        /*
         * api_key (Required) : A Last.fm API key.
         * 
         * api_sig (Required) : A Last.fm method signature. See authentication for more information.
         * 
         */
        /// <summary>
        /// auth.getToken
        /// </summary>
        /// <returns></returns>
        AuthToken GetToken();

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
        /// <summary>
        /// auth.getSession
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        AuthSession GetSession(string token);

        #endregion
    }
}