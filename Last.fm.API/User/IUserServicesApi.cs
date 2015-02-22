//-----------------------------------------------------------------------
// <copyright file="IUserServicesApi.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ServiceModel;
using System.ServiceModel.Web;
using Last.fm.API.Core;
using Last.fm.API.Core.Web;

namespace Last.fm.API.User
{
    [Service("User")]
    internal interface IUserServicesApi : IApiKeys
    {
        #region Don't use User Authentication

        #region user.getRecentTracks

        /// <summary>
        /// Get a list of the recent tracks listened to by this user. Also includes the
        /// currently playing track with the nowplaying="true" attribute if the user
        /// is currently listening.
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="user">user (Required) : The last.fm username to fetch the recent tracks of.</param>
        /// <param name="limit">limit (Optional) : The number of results to fetch per page. Defaults
        /// to 50. Maximum is 200.</param>
        /// <param name="page">page (Optional) : The page number to fetch. Defaults to first page.</param>
        /// <param name="extended">extended (0|1) (Optional) : Includes extended data in each artist,
        /// and whether or not the user has loved each track.</param>
        /// <param name="from">from (Optional) : Beginning timestamp of a range - only display scrobbles
        /// after this time, in UNIX timestamp format (integer number of seconds since 00:00:00, January
        /// 1st 1970 UTC). This must be in the UTC time zone.</param>
        /// <param name="to">to (Optional) : End timestamp of a range - only display scrobbles before
        /// this time, in UNIX timestamp format (integer number of seconds since 00:00:00, January 1st
        /// 1970 UTC). This must be in the UTC time zone.</param>
        /// <returns></returns>
        [WebMethod("user.getRecentTracks")]
        RecentTracksCollection GetRecentTracks([Parameter("api_key")] string apiKey, [Parameter("user")] string user, [Parameter("limit")] int? limit = null, [Parameter("page")] int? page = null, [Parameter("extended")] bool? extended = null, [Parameter("from")] int? from = null, [Parameter("to")] int? to = null);

        #endregion

        #region user.getArtistTracks

        /// <summary>
        /// Get a list of tracks by a given artist scrobbled by this user, including scrobble time.
        /// Can be limited to specific timeranges, defaults to all time. 
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="user">user (Required) : The last.fm username to fetch the recent tracks of.</param>
        /// <param name="artist">artist (Required) : The artist name you are interested in.</param>
        /// <param name="page">page (Optional) : The page number to fetch. Defaults to first page.</param>
        /// <param name="startTimestamp">startTimestamp (Optional) : An unix timestamp to start at.</param>
        /// <param name="endTimestamp">endTimestamp (Optional) : An unix timestamp to end at.</param>
        /// <returns>Return collection of artist tracks.</returns>
        [WebMethod("user.getArtistTracks")]
        ArtistTracksCollection GetArtistTracks([Parameter("api_key")] string apiKey, [Parameter("user")] string user, [Parameter("artist")] string artist, [Parameter("page")] int? page = null, [Parameter("startTimestamp")] double? startTimestamp = null, [Parameter("endTimestamp")] double? endTimestamp = null);
        
        #endregion

        #region user.getBannedTracks

        /// <summary>
        /// Returns the tracks banned by the user.
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="user">user (Required) : The user name.</param>
        /// <param name="limit">limit (Optional) : The number of results to fetch per page. Defaults to 50.</param>
        /// <param name="page">page (Optional) : The page number to fetch. Defaults to first page.</param>
        /// <returns>Return collection of banned tracks.</returns>
        [WebMethod("user.getBannedTracks")]
        BannedTracksCollection GetBannedTracks([Parameter("api_key")] string apiKey, [Parameter("user")] string user, [Parameter("limit")] int? limit = null, [Parameter("page")] int? page = null);
        
        #endregion

        #region user.getEvents

        /// <summary>
        /// Get a list of upcoming events that this user is attending. Easily integratable into
        /// calendars, using the ical standard (see 'more formats' section below).
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="user">user (Required) : The user to fetch the events for.</param>
        /// <param name="page">page (Optional) : The page number to fetch. Defaults to first page.</param>
        /// <param name="festivalsonly">festivalsonly[0|1] (Optional) : Whether only festivals should be returned, or all events.</param>
        /// <param name="limit">limit (Optional) : The number of results to fetch per page. Defaults to 50.</param>
        /// <returns>Returns collection of upcoming events.</returns>
        [WebMethod("user.getEvents")]
        UpcomingEventsCollection GetEvents([Parameter("api_key")]string apiKey, [Parameter("user")]string user, [Parameter("page")]int? page = null, [Parameter("festivalsonly")]byte? festivalsonly = null, [Parameter("limit")]int? limit = null);
        
        #endregion

        #region user.getFriends

        /// <summary>
        /// Get a list of the user's friends on Last.fm.
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="user">user (Required) : The last.fm username to fetch the friends of.</param>
        /// <param name="recenttracks">recenttracks [0/1](Optional) : Whether or not to include information
        /// about friends' recent listening in the response.</param>
        /// /// <param name="page">page (Optional) : The page number to fetch. Defaults to first page.</param>
        /// <param name="limit">limit (Optional) : The number of results to fetch per page. Defaults to 50.</param>
        /// <returns></returns>
        [WebMethod("user.getFriends")]
        FriendsCollection GetFriends([Parameter("api_key")] string apiKey, [Parameter("user")] string user, [Parameter("recenttracks")]bool? recenttracks = null, [Parameter("page")]int? page = null, [Parameter("limit")] int? limit = null);
        
        #endregion

        #region user.getInfo

        /// <summary>
        /// Get information about a user profile. 
        /// </summary>
        /// <param name="apiKey">user (Optional) : The user to fetch info for. Defaults to the authenticated user.</param>
        /// <param name="user">api_key (Required) : A Last.fm API key.</param>
        /// <returns>Return user information.</returns>
        [WebMethod("user.getInfo")]
        UserInfo GetInfo([Parameter("api_key")] string apiKey, [Parameter("user")] string user);
        
        #endregion

        #region user.getTopTags

        /// <summary>
        /// Get the top tags used by this user.
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="user">user (Required) : The user name.</param>
        /// <param name="limit">limit (Optional) : Limit the number of tags returned.</param>
        /// <returns>Return top tags collection.</returns>
        [WebMethod("user.getTopTags")]
        TagsCollection GetTopTags([Parameter("api_key")] string apiKey, [Parameter("user")] string user, [Parameter("limit")] int? limit = null);

        #endregion

        #region user.getLovedTracks

        /// <summary>
        /// Get the last 50 tracks loved by a user.
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="user">user (Required) : The user name to fetch the loved tracks for.</param>
        /// <param name="limit">limit (Optional) : The number of results to fetch per page. Defaults to 50.</param>
        /// <param name="page">page (Optional) : The page number to fetch. Defaults to first page.</param>
        /// <returns>Return collection of loved tracks.</returns>
        [WebMethod("user.getLovedTracks")]
        LovedTracksCollection GetLovedTracks([Parameter("api_key")] string apiKey, [Parameter("user")] string user, [Parameter("limit")] int? limit = null, [Parameter("page")] int? page = null);
        
        #endregion

        #region user.getNeighbours

        /// <summary>
        /// Get a list of a user's neighbours on Last.fm.
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="user">user (Required) : The last.fm username to fetch the neighbours of.</param>
        /// <param name="limit">limit (Optional) : The number of results to fetch per page. Defaults to 50.</param>
        /// <returns>Return collection of neighbours</returns>
        [WebMethod("user.getNeighbours")]
        NeighboursCollection GetNeighbours([Parameter("api_key")] string apiKey, [Parameter("user")] string user, [Parameter("limit")] int? limit = null);
        
        #endregion

        #region user.getNewReleases

        /// <summary>
        /// Gets a list of forthcoming releases based on a user's musical taste.
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="user">user (Required) : The Last.fm username.</param>
        /// <param name="userecs">userecs (Optional) : 0 or 1. If 1, the feed contains new releases based
        /// on Last.fm's artist recommendations for this user. Otherwise, it is based on their library
        /// (the default).</param>
        /// <returns>Return collection with new releases albums.</returns>
        [WebMethod("user.getNewReleases")]
        NewReleasesCollection GetNewReleases([Parameter("api_key")] string apiKey, [Parameter("user")] string user, [Parameter("userecs")] bool? userecs = null);
        
        #endregion

        #region user.getPastEvents

        /// <summary>
        /// Get a paginated list of all events a user has attended in the past.
        /// </summary>
        /// <param name="apiKey">api_key (Required) : A Last.fm API key.</param>
        /// <param name="user">user (Required) : The username to fetch the events for.</param>
        /// <param name="limit">limit (Optional) : The number of results to fetch per page. Defaults to 50.</param>
        /// <param name="page">page (Optional) : The page number to scan to.</param>
        /// <returns>Return collection of past events.</returns>
        [WebMethod("user.getPastEvents")]
        PastEventsCollection GetPastEvents([Parameter("api_key")] string apiKey, [Parameter("user")] string user, [Parameter("limit")] int? limit = null, [Parameter("page")] int? page = null);

        #endregion

        #region user.getPersonalTags

        /*
         * user (Required) : The user who performed the taggings.
         * tag (Required) : The tag you're interested in.
         * taggingtype[artist|album|track] (Required) : The type of items which have been tagged
         * limit (Optional) : The number of results to fetch per page. Defaults to 50.
         * page (Optional) : The page number to fetch. Defaults to first page.
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getPersonalTags&api_key={apiKey}&user={user}&tag={tag}&taggingtype={taggingtype}&limit={limit}&page={page}")]
        BaseResponse GetPersonalTags(string apiKey, string user, string tag, string taggingtype, int? limit = null, int? page = null);

        #endregion

        #region user.getPlaylists

        /*
         * user (Required) : The last.fm username to fetch the playlists of.
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getPlaylists&api_key={apiKey}&user={user}")]
        BaseResponse GetPlaylists(string apiKey, string user);

        #endregion

        #endregion

        #region Use User Authentication

        #region user.getRecentStations

        /*
         * user (Required) : The last.fm username to fetch the recent Stations of.
         * limit (Optional) : The number of results to fetch per page. Defaults to 10. Maximum is 25.
         * page (Optional) : The page number to fetch. Defaults to first page.
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         * api_sig (Required) : A Last.fm method signature. See authentication for more information.
         * sk (Required) : A session key generated by authenticating a user via the authentication protocol. 
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getRecentStations&api_key={apiKey}&user={user}&limit={limit}&page={page}&api_sig={apiSig}&sk={sk}")]
        BaseResponse GetRecentStations(string apiKey, string user, string apiSig, string sk, int? limit = null, int? page = null);

        #endregion

        #region user.getRecommendedArtists

        /*
         * page (Optional) : The page number to fetch. Defaults to first page.
         * limit (Optional) : The number of results to fetch per page. Defaults to 50.
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         * api_sig (Required) : A Last.fm method signature. See authentication for more information.
         * sk (Required) : A session key generated by authenticating a user via the authentication protocol. 
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getRecommendedArtists&api_key={apiKey}&limit={limit}&page={page}&api_sig={apiSig}&sk={sk}")]
        BaseResponse GetRecommendedArtists(string apiKey, string apiSig, string sk, int? limit = null, int? page = null);

        #endregion

        #region user.getRecommendedEvents

        /*
         * imit (Optional) : The number of results to fetch per page. Defaults to 20.
         * page (Optional) : The page number to scan to.
         * latitude (Optional) : Optionally find events at a particular location (must be paired with a valid longitude)
         * longitude (Optional) : Optionally find events at a particular location (must be paired with a valid latitude)
         * festivalsonly[0|1] (Optional) : Whether only festivals should be returned, or all events.
         * country (Optional) : Optionally find events in a particular country (use EITHER lat/long or country)
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         * api_sig (Required) : A Last.fm method signature. See authentication for more information.
         * sk (Required) : A session key generated by authenticating a user via the authentication protocol. 
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getRecommendedEvents&api_key={apiKey}&limit={limit}&page={page}&api_sig={apiSig}&sk={sk}" +
                          "&latitude={latitude}&longitude={longitude}&country={country}&festivalsonly={festivalsonly}")]
        BaseResponse GetRecommendedEvents(string apiKey, string apiSig, string sk, int? limit = null, int? page = null,
            string latitude = null, string longitude = null, byte? festivalsonly = null, string country = null);

        #endregion

        #endregion
    }
}
