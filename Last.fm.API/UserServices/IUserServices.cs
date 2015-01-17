﻿using System;
using System.Xml;
using Last.fm.API.BaseLastFm;
using Last.fm.API.Core;

namespace Last.fm.API.UserServices
{
    /// <summary>
    /// Set of API Methods for User section
    /// </summary>
    public interface IUserServices : IApiKeys, IDisposable
    {
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
         */
        BaseResponse GetRecentTracks(string user, int? limit = null, int? page = null, byte? extended = null, double? from = null, double? to = null);

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
        BaseResponse GetArtistTracks(string user, string artist, int? page = null, DateTime? endTimestamp = null);

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
        BaseResponse GetBannedTracks(string user, int? limit = null, int? page = null);

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
        BaseResponse GetEvents(string user, int? page = null, byte? festivalsonly = null, int? limit = null);

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
        BaseResponse GetFriends(string user, int? page = null, byte? recenttracks = 0, int? limit = null);

        #endregion

        #region user.getInfo

        /*
         * user (Optional) : The user to fetch info for. Defaults to the authenticated user.
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         */
        BaseResponse GetInfo(string user);

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
        BaseResponse GetLovedTracks(string user, int? limit = null, int? page = null);

        #endregion

        #region user.getNeighbours

        /*
         * user (Required) : The last.fm username to fetch the neighbours of.
         * limit (Optional) : The number of results to fetch per page. Defaults to 50.
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         */
        BaseResponse GetNeighbours(string user, int? limit = null);

        #endregion

        #region user.getNewReleases

        /*
         * user (Required) : The Last.fm username.
         * userecs (Optional) : 0 or 1. If 1, the feed contains new releases based on Last.fm's artist recommendations for this user. Otherwise, it is based on their library (the default).
         * 
         * api_key (Required) : A Last.fm API key.
         * 
         */
        BaseResponse GetNewReleases(string user, byte? userecs = 0);

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
        BaseResponse GetPastEvents(string user, int? limit = null, int? page = null);

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
