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
        /// Get client for User Service
        /// </summary>
        public static IUserServices UserServicesClient
        {
            get { return new UserServicesClient(); }
        }

        /// <summary>
        /// Get client for Auth Service
        /// </summary>
        public static IAuthServices AuthServicesClient
        {
            get { return new AuthServicesClient(); }
        }

        /// <summary>
        /// Get client for ArtistService
        /// </summary>
        public static IArtistServices ArtistServicesClient
        {
            get { return new ArtistServicesClient(); }
        }

        #endregion
    }
}