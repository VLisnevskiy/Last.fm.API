//-----------------------------------------------------------------------
// <copyright file="IUserServices.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Last.fm.API.Core;
using Last.fm.API.Core.Types;

namespace Last.fm.API.User
{
    /// <summary>
    /// Set of API Methods for User section
    /// </summary>
    public interface IUserServices : IApiKeys, IDisposable
    {
        #region user.getRecentTracks

        /// <summary>
        /// Get a list of the recent tracks listened to by this user. Also includes the
        /// currently playing track with the nowplaying="true" attribute if the user
        /// is currently listening.
        /// </summary>
        /// <param name="user">The last.fm username to fetch the recent tracks of.</param>
        /// <param name="limit">The number of results to fetch per page. Defaults to 50.
        /// Maximum is 200.</param>
        /// <param name="page">The page number to fetch. Defaults to first page.</param>
        /// <param name="extended">Includes extended data in each artist, and whether or not
        /// the user has loved each track.</param>
        /// <param name="from">Beginning timestamp of a range - only display scrobbles after
        /// this time, in UNIX timestamp format (integer number of seconds since 00:00:00,
        /// January 1st 1970 UTC). This must be in the UTC time zone.</param>
        /// <param name="to">End timestamp of a range - only display scrobbles before this time,
        /// in UNIX timestamp format (integer number of seconds since 00:00:00, January 1st
        /// 1970 UTC). This must be in the UTC time zone.</param>
        /// <returns>Return recent tracks collection</returns>
        RecentTracksCollection GetRecentTracks(string user, int? limit = 50, int? page = null, bool? extended = null, int? from = null, int? to = null);

        #endregion

        #region user.getArtistTracks

        /// <summary>
        /// Get a list of tracks by a given artist scrobbled by this user, including scrobble time.
        /// Can be limited to specific timeranges, defaults to all time. 
        /// </summary>
        /// <param name="user">user (Required) : The last.fm username to fetch the recent tracks of.</param>
        /// <param name="artist">artist (Required) : The artist name you are interested in.</param>
        /// <param name="page">page (Optional) : The page number to fetch. Defaults to first page.</param>
        /// <param name="startTimestamp">startTimestamp (Optional) : An unix timestamp to start at.</param>
        /// <param name="endTimestamp">endTimestamp (Optional) : An unix timestamp to end at.</param>
        /// <returns>Return collection of artist tracks.</returns>
        ArtistTracksCollection GetArtistTracks(string user, string artist, int? page = null, DateTime? startTimestamp = null, DateTime? endTimestamp = null);

        #endregion

        #region user.getBannedTracks

        /// <summary>
        /// Returns the tracks banned by the user.
        /// </summary>
        /// <param name="user">user (Required) : The user name.</param>
        /// <param name="limit">limit (Optional) : The number of results to fetch per page. Defaults to 50.</param>
        /// <param name="page">page (Optional) : The page number to fetch. Defaults to first page.</param>
        /// <returns>Return collection of banned tracks.</returns>
        BannedTracksCollection GetBannedTracks(string user, int? limit = null, int? page = null);

        #endregion

        #region user.getEvents

        /// <summary>
        /// Get a list of upcoming events that this user is attending. Easily integratable into
        /// calendars, using the ical standard (see 'more formats' section below).
        /// </summary>
        /// <param name="user">user (Required) : The user to fetch the events for.</param>
        /// <param name="page">page (Optional) : The page number to fetch. Defaults to first page.</param>
        /// <param name="festivalsonly">festivalsonly[0|1] (Optional) : Whether only festivals should be returned, or all events.</param>
        /// <param name="limit">limit (Optional) : The number of results to fetch per page. Defaults to 50.</param>
        /// <returns>Returns collection of upcoming events.</returns>
        UpcomingEventsCollection GetEvents(string user, int? page = null, byte? festivalsonly = null, int? limit = null);

        #endregion

        #region user.getFriends

        /// <summary>
        /// Get a list of the user's friends on Last.fm.
        /// </summary>
        /// <param name="user">user (Required) : The last.fm username to fetch the friends of.</param>
        /// <param name="recenttracks">recenttracks [0/1](Optional) : Whether or not to include information
        /// about friends' recent listening in the response.</param>
        /// <param name="page">page (Optional) : The page number to fetch. Defaults to first page.</param>
        /// <param name="limit">limit (Optional) : The number of results to fetch per page. Defaults to 50.</param>
        /// <returns></returns>
        FriendsCollection GetFriends(string user, bool? recenttracks = null, int? page = null, int? limit = null);

        #endregion

        #region user.getInfo

        /// <summary>
        /// Get information about a user profile. 
        /// </summary>
        /// <param name="user">The user to fetch info for. Defaults to the authenticated user.</param>
        /// <returns>User information</returns>
        UserInfo GetInfo(string user);

        #endregion

        #region user.getTopTags

        /// <summary>
        /// Get the top tags used by this user.
        /// </summary>
        /// <param name="user">user (Required) : The user name.</param>
        /// <param name="limit">limit (Optional) : Limit the number of tags returned.</param>
        /// <returns></returns>
        TagsCollection GetTopTags(string user, int? limit = null);

        #endregion

        #region user.getLovedTracks

        /// <summary>
        /// Get the last 50 tracks loved by a user.
        /// </summary>
        /// <param name="user">user (Required) : The user name to fetch the loved tracks for.</param>
        /// <param name="limit">limit (Optional) : The number of results to fetch per page. Defaults to 50.</param>
        /// <param name="page">page (Optional) : The page number to fetch. Defaults to first page.</param>
        /// <returns>Return collection of loved tracks.</returns>
        LovedTracksCollection GetLovedTracks(string user, int? limit = null, int? page = null);

        #endregion

        #region user.getNeighbours

        /// <summary>
        /// Get a list of a user's neighbours on Last.fm.
        /// </summary>
        /// <param name="user">user (Required) : The last.fm username to fetch the neighbours of.</param>
        /// <param name="limit">limit (Optional) : The number of results to fetch per page. Defaults to 50.</param>
        /// <returns>Return collection of neighbours</returns>
        NeighboursCollection GetNeighbours(string user, int? limit = null);

        #endregion

        #region user.getNewReleases

        /// <summary>
        /// Gets a list of forthcoming releases based on a user's musical taste.
        /// </summary>
        /// <param name="user">user (Required) : The Last.fm username.</param>
        /// <param name="userecs">userecs (Optional) : 0 or 1. If 1, the feed contains new releases based
        /// on Last.fm's artist recommendations for this user. Otherwise, it is based on their library
        /// (the default).</param>
        /// <returns>Return collection with new releases albums.</returns>
        NewReleasesCollection GetNewReleases(string user, bool? userecs = null);

        #endregion

        #region user.getPastEvents

        /// <summary>
        /// Get a paginated list of all events a user has attended in the past.
        /// </summary>
        /// <param name="user">user (Required) : The username to fetch the events for.</param>
        /// <param name="limit">limit (Optional) : The number of results to fetch per page. Defaults to 50.</param>
        /// <param name="page">page (Optional) : The page number to scan to.</param>
        /// <returns>Return collection of past events.</returns>
        PastEventsCollection GetPastEvents(string user, int? limit = null, int? page = null);

        #endregion

        #region user.getPersonalTags

        /*
         * user (Required) : The user who performed the taggings.
         * tag (Required) : The tag you're interested in.
         * taggingType[artist|album|track] (Required) : The type of items which have been tagged
         * limit (Optional) : The number of results to fetch per page. Defaults to 50.
         * page (Optional) : The page number to fetch. Defaults to first page.
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         */
        BaseResponse GetPersonalTags(string user, string tag, TaggingType taggingType, int? limit = null, int? page = null);

        #endregion

    }
}
