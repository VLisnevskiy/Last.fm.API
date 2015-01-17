//-----------------------------------------------------------------------
// <copyright file="LastFmServicesHolder.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Last.fm.API.Artist;
using Last.fm.API.Auth;
using Last.fm.API.UserServices;

namespace Last.fm.API.Core
{
    /// <summary>
    /// Holder for Last.fm web services
    /// </summary>
    public static class LastFmServicesHolder
    {
        #region Public Methods

        /// <summary>
        /// Create client for User Service
        /// </summary>
        /// <returns></returns>
        public static IUserServices CreateUserServicesClient()
        {
            return new UserServicesClient();
        }

        /// <summary>
        /// Create client for Auth Service
        /// </summary>
        /// <returns></returns>
        public static IAuthServices CreateAuthServicesClient()
        {
            return new AuthServicesClient();
        }

        /// <summary>
        /// Create client for ArtistService
        /// </summary>
        /// <returns></returns>
        public static IArtistServices CreateArtistServicesClientProxy()
        {
            return new ArtistServicesClient();
        }

        #endregion
    }
}