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
        /// <param name="token"></param>
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