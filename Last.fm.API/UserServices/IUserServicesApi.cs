using System.ServiceModel;
using System.ServiceModel.Web;
using System.Xml;
using Last.fm.API.BaseLastFm;

namespace Last.fm.API.UserServices
{
    [ServiceContract]
    [XmlSerializerFormat]
    internal interface IUserServicesApi : IApiKeys
    {
        #region Don't use User Authentication

        #region user.getRecentTracks

        /*
         * user.getRecentTracks
         * 
         * limit (Optional) : The number of results to fetch per page. Defaults to 50. Maximum is 200.
         * user (Required) : The last.fm username to fetch the recent tracks of.
         * page (Optional) : The page number to fetch. Defaults to first page.
         * from (Optional) : Beginning timestamp of a range - only display scrobbles after this time, in UNIX timestamp format (integer number of seconds since 00:00:00, January 1st 1970 UTC). This must be in the UTC time zone.
         * extended (0|1) (Optional) : Includes extended data in each artist, and whether or not the user has loved each track
         * to (Optional) : End timestamp of a range - only display scrobbles before this time, in UNIX timestamp format (integer number of seconds since 00:00:00, January 1st 1970 UTC). This must be in the UTC time zone.
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getRecentTracks&raw=true&api_key={apiKey}&user={user}&limit={limit}&page={page}&extended={extended}&from={from}&to={to}")]
        XmlDocument GetRecentTracks(string apiKey, string user, int? limit = null, int? page = null, byte? extended = null, double? from = null, double? to = null);

        #endregion

        #region user.getArtistTracks

        /*
         * user (Required) : The last.fm username to fetch the recent tracks of.
         * artist (Required) : The artist name you are interested in
         * startTimestamp (Optional) : An unix timestamp to start at.
         * page (Optional) : The page number to fetch. Defaults to first page.
         * endTimestamp (Optional) : An unix timestamp to end at.
         * 
         * api_key (Required) : A Last.fm API key. 
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getArtistTracks&raw=true&api_key={apiKey}&user={user}&artist={artist}&page={page}&endTimestamp={endTimestamp}")]
        XmlDocument GetArtistTracks(string apiKey, string user, string artist, int? page = null, double? endTimestamp = null);
        
        #endregion

        #region user.getBannedTracks

        /*
         * user (Required) : The user name
         * limit (Optional) : The number of results to fetch per page. Defaults to 50.
         * page (Optional) : The page number to fetch. Defaults to first page.
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getBannedTracks&raw=true&api_key={apiKey}&user={user}&limit={limit}&page={page}")]
        XmlDocument GetBannedTracks(string apiKey, string user, int? limit = null, int? page = null);
        
        #endregion

        #region user.getEvents

        /*
         * user (Required) : The user to fetch the events for.
         * page (Optional) : The page number to fetch. Defaults to first page.
         * festivalsonly[0|1] (Optional) : Whether only festivals should be returned, or all events.
         * limit (Optional) : The number of results to fetch per page. Defaults to 50.
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getEvents&raw=true&api_key={apiKey}&user={user}&page={page}&festivalsonly={festivalsonly}&limit={limit}")]
        XmlDocument GetEvents(string apiKey, string user, int? page = null, byte? festivalsonly = null, int? limit = null);
        
        #endregion

        #region user.getFriends

        /*
         * user (Required) : The last.fm username to fetch the friends of.
         * recenttracks [0/1](Optional) : Whether or not to include information about friends' recent listening in the response.
         * limit (Optional) : The number of results to fetch per page. Defaults to 50.
         * page (Optional) : The page number to fetch. Defaults to first page.
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getFriends&raw=true&api_key={apiKey}&user={user}&page={page}&recenttracks={recenttracks}&limit={limit}")]
        XmlDocument GetFriends(string apiKey, string user, int? page = null, byte? recenttracks = 0, int? limit = null);
        
        #endregion

        #region user.getInfo

        /*
         * user (Optional) : The user to fetch info for. Defaults to the authenticated user.
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getInfo&raw=true&api_key={apiKey}&user={user}")]
        XmlDocument GetInfo(string apiKey, string user);
        
        #endregion

        #region user.getLovedTracks

        /*
         * user (Required) : The user name to fetch the loved tracks for.
         * limit (Optional) : The number of results to fetch per page. Defaults to 50.
         * page (Optional) : The page number to fetch. Defaults to first page.
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getLovedTracks&raw=true&api_key={apiKey}&user={user}&limit={limit}&page={page}")]
        XmlDocument GetLovedTracks(string apiKey, string user, int? limit = null, int? page = null);
        
        #endregion

        #region user.getNeighbours

        /*
         * user (Required) : The last.fm username to fetch the neighbours of.
         * limit (Optional) : The number of results to fetch per page. Defaults to 50.
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getNeighbours&raw=true&api_key={apiKey}&user={user}&limit={limit}")]
        XmlDocument GetNeighbours(string apiKey, string user, int? limit = null);
        
        #endregion

        #region user.getNewReleases

        /*
         * user (Required) : The Last.fm username.
         * userecs (Optional) : 0 or 1. If 1, the feed contains new releases based on Last.fm's artist recommendations for this user. Otherwise, it is based on their library (the default).
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getNewReleases&raw=true&api_key={apiKey}&user={user}&userecs={userecs}")]
        XmlDocument GetNewReleases(string apiKey, string user, byte? userecs = 0);
        
        #endregion

        #region user.getPastEvents

        /*
         * user (Required) : The username to fetch the events for.
         * page (Optional) : The page number to scan to.
         * limit (Optional) : The number of results to fetch per page. Defaults to 50.
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         */
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=user.getPastEvents&raw=true&api_key={apiKey}&user={user}&limit={limit}&page={page}")]
        XmlDocument GetPastEvents(string apiKey, string user, int? limit = null, int? page = null);

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
            UriTemplate = "?method=user.getPersonalTags&raw=true&api_key={apiKey}&user={user}&tag={tag}&taggingtype={taggingtype}&limit={limit}&page={page}")]
        XmlDocument GetPersonalTags(string apiKey, string user, string tag, string taggingtype, int? limit = null, int? page = null);

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
            UriTemplate = "?method=user.getPlaylists&raw=true&api_key={apiKey}&user={user}")]
        XmlDocument GetPlaylists(string apiKey, string user);

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
            UriTemplate = "?method=user.getRecentStations&raw=true&api_key={apiKey}&user={user}&limit={limit}&page={page}&api_sig={apiSig}&sk={sk}")]
        XmlDocument GetRecentStations(string apiKey, string user, string apiSig, string sk, int? limit = null, int? page = null);

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
            UriTemplate = "?method=user.getRecommendedArtists&raw=true&api_key={apiKey}&limit={limit}&page={page}&api_sig={apiSig}&sk={sk}")]
        XmlDocument GetRecommendedArtists(string apiKey, string apiSig, string sk, int? limit = null, int? page = null);

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
            UriTemplate = "?method=user.getRecommendedEvents&raw=true&api_key={apiKey}&limit={limit}&page={page}&api_sig={apiSig}&sk={sk}" +
                          "&latitude={latitude}&longitude={longitude}&country={country}&festivalsonly={festivalsonly}")]
        XmlDocument GetRecommendedEvents(string apiKey, string apiSig, string sk, int? limit = null, int? page = null,
            string latitude = null, string longitude = null, byte? festivalsonly = null, string country = null);

        #endregion

        #endregion
    }
}
