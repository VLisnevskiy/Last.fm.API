//-----------------------------------------------------------------------
// <copyright file="IAuthServices.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
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
        /// auth.getMobileSession
        /// </summary>
        /// <param name="password"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        [Obsolete]
        AuthSession GetMobileSession(string password, string username);

        #endregion

        #region auth.getToken

        /// <summary>
        /// auth.getToken
        /// </summary>
        /// <returns></returns>
        AuthToken GetToken();

        #endregion

        #region auth.getSession

        /// <summary>
        /// auth.getSession
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        AuthSession GetSession(string token);

        #endregion
    }
}