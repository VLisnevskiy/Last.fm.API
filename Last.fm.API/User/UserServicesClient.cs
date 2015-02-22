//-----------------------------------------------------------------------
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

        public BaseResponse GetLovedTracks(string user, int? limit = null, int? page = null)
        {
            var result = Channel.GetLovedTracks(ApiKey, user, limit, page);
            return result;
        }

        public BaseResponse GetNeighbours(string user, int? limit = null)
        {
            var result = Channel.GetNeighbours(ApiKey, user, limit);
            return result;
        }

        public BaseResponse GetNewReleases(string user, byte? userecs = 0)
        {
            var result = Channel.GetNewReleases(ApiKey, user, userecs);
            return result;
        }

        public BaseResponse GetPastEvents(string user, int? limit = null, int? page = null)
        {
            var result = Channel.GetPastEvents(ApiKey, user, limit, page);
            return result;
        }

        public BaseResponse GetPersonalTags(string user, string tag, TaggingType taggingType, int? limit = null, int? page = null)
        {
            var result = Channel.GetPersonalTags(ApiKey, user, tag, taggingType.ToString().ToLowerInvariant(), limit, page);
            return result;
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
