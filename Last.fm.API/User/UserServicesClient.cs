﻿//-----------------------------------------------------------------------
// <copyright file="UserServicesClient.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
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

        public BaseResponse GetRecentTracks(string user, int? limit = null, int? page = null, byte? extended = null,
                                           double? from = 0, double? to = 0)
        {
            var result = Channel.GetRecentTracks(ApiKey, user, limit, page, extended, from, to);
            return result;
        }

        public BaseResponse GetArtistTracks(string user, string artist, int? page = null, DateTime? endTimestamp = null)
        {
            var result = Channel.GetArtistTracks(ApiKey, user, artist, page, endTimestamp.ConvertToTimestamp());
            return result;
        }

        public BaseResponse GetBannedTracks(string user, int? limit = null, int? page = null)
        {
            var result = Channel.GetBannedTracks(ApiKey, user, limit, page);
            return result;
        }

        public BaseResponse GetEvents(string user, int? page = null, byte? festivalsonly = null, int? limit = null)
        {
            var result = Channel.GetEvents(ApiKey, user, page, festivalsonly, limit);
            return result;
        }

        public BaseResponse GetFriends(string user, int? page = null, byte? recenttracks = 0, int? limit = null)
        {
            var result = Channel.GetFriends(ApiKey, user, page, recenttracks, limit);
            return result;
        }

        public BaseResponse GetInfo(string user)
        {
            var result = Channel.GetInfo(ApiKey, user);
            return result;
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