//-----------------------------------------------------------------------
// <copyright file="LastFmServices.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Last.fm.API.Artist;
using Last.fm.API.Auth;
using Last.fm.API.User;

namespace Last.fm.API
{
    /// <summary>
    /// Holder for Last.fm web services
    /// </summary>
    public static class LastFmServices
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