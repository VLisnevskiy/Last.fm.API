﻿//-----------------------------------------------------------------------
// <copyright file="UserServicesClient.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Last.fm.API.Core;
using Last.fm.API.Core.Types;

namespace Last.fm.API.User
{
    internal class UserServicesClient : BaseLastFmClient<IUserServicesApi>, IUserServices
    {
        #region IUserServices methods

        public RecentTracksCollection GetRecentTracks(string user, int? limit = 50, int? page = null, bool? extended = null, int? from = 0, int? to = 0)
        {
            return Channel.GetRecentTracks(ApiKey, user, limit, page, extended, from, to);
        }

        public ArtistTracksCollection GetArtistTracks(string user, string artist, int? page = null, DateTime? startTimestamp = null, DateTime? endTimestamp = null)
        {
            return Channel.GetArtistTracks(ApiKey, user, artist, page, startTimestamp.ToTimestamp(), endTimestamp.ToTimestamp());
        }

        public BannedTracksCollection GetBannedTracks(string user, int? limit = null, int? page = null)
        {
            return Channel.GetBannedTracks(ApiKey, user, limit, page);
        }

        public UpcomingEventsCollection GetEvents(string user, int? page = null, byte? festivalsonly = null, int? limit = null)
        {
            return Channel.GetEvents(ApiKey, user, page, festivalsonly, limit);
        }

        public FriendsCollection GetFriends(string user, bool? recenttracks = null, int? page = null, int? limit = null)
        {
            return Channel.GetFriends(ApiKey, user, recenttracks, page, limit);
        }

        public UserInfo GetInfo(string user)
        {
            return Channel.GetInfo(ApiKey, user);
        }

        public TagsCollection GetTopTags(string user, int? limit = null)
        {
            return Channel.GetTopTags(ApiKey, user, limit);
        }

        public LovedTracksCollection GetLovedTracks(string user, int? limit = null, int? page = null)
        {
            return Channel.GetLovedTracks(ApiKey, user, limit, page);
        }

        public NeighboursCollection GetNeighbours(string user, int? limit = null)
        {
            return Channel.GetNeighbours(ApiKey, user, limit);
        }

        public NewReleasesCollection GetNewReleases(string user, bool? userecs = null)
        {
            return Channel.GetNewReleases(ApiKey, user, userecs);
        }

        public PastEventsCollection GetPastEvents(string user, int? limit = null, int? page = null)
        {
            return Channel.GetPastEvents(ApiKey, user, limit, page);
        }

        public BaseResponse GetPersonalTags(string user, string tag, TaggingType taggingType, int? limit = null, int? page = null)
        {
            return Channel.GetPersonalTags(ApiKey, user, tag, taggingType.ToString().ToLowerInvariant(), limit, page);
        }

        public PlaylistsCollection GetPlaylists(string user)
        {
            return Channel.GetPlaylists(ApiKey, user);
        }

        public BaseResponse GetShouts(string user, int? limit = null, int? page = null)
        {
            return Channel.GetShouts(ApiKey, user, limit, page);
        }

        public BaseResponse GetTopAlbums(string user, string period = "overall", int? limit = null, int? page = null)
        {
            return Channel.GetTopAlbums(ApiKey, user, period, limit, page);
        }

        public BaseResponse GetTopArtists(string user, string period = "overall", int? limit = null, int? page = null)
        {
            return Channel.GetTopArtists(ApiKey, user, period, limit, page);
        }

        #endregion

        #region IDisposable

        ~UserServicesClient()
        {
            Dispose(false);
        }

        #endregion
    }
}
