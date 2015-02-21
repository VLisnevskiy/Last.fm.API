//-----------------------------------------------------------------------
// <copyright file="IAuthServices.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Last.fm.API.Core;

namespace Last.fm.API.Auth
{
    /// <summary>
    /// Set of API Methods for Auth section
    /// </summary>
    public interface IAuthServices : IApiKeys, IDisposable
    {
        #region auth.getMobileSession

        /// <summary>
        /// Create a web service session for a user. Used for authenticating a user when the password
        /// can be inputted by the user. Accepts email address as well, so please use the username supplied
        /// in the output. Only suitable for standalone mobile devices. See the authentication how-to for more.
        /// You must use HTTPS and POST in order to use this method.
        /// </summary>
        /// <param name="password">The password in plain text.</param>
        /// <param name="username">The last.fm username or email address.</param>
        /// <returns></returns>
        AuthSession GetMobileSession(string password, string username);

        #endregion

        #region auth.getToken

        /// <summary>
        /// Fetch an unathorized request token for an API account.
        /// </summary>
        /// <returns>AuthToken</returns>
        AuthToken GetToken();

        #endregion

        #region auth.getSession

        /// <summary>
        /// Fetch a session key for a user.
        /// </summary>
        /// <param name="token">A 32-character ASCII hexadecimal MD5 hash returned by step 1
        /// of the authentication process (following the granting of permissions to the
        /// application by the user)</param>
        /// <returns>AuthSession</returns>
        AuthSession GetSession(string token);

        /// <summary>
        /// Fetch a session key for a user. Token will be taken from settings.
        /// </summary>
        /// <returns>AuthSession</returns>
        AuthSession GetSession();

        /// <summary>
        /// Occurs when using token not authorized.
        /// </summary>
        event EventHandler<NotAuthorizedTokenEventArgs> NotAuthorizedToken;

        #endregion
    }
}