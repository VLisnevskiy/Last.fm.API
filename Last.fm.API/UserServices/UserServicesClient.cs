using System;
using System.Xml;
using Last.fm.API.BaseLastFm;

namespace Last.fm.API.UserServices
{
    internal class UserServicesClient : BaseLastFmClient<IUserServicesApi>, IUserServices
    {
        public UserServicesClient(string apiKey)
            : base(apiKey)
        {
        }

        #region IUserServices methods

        public XmlDocument GetRecentTracks(string user, int? limit = null, int? page = null, byte? extended = null,
                                           double? @from = null, double? to = null)
        {
            var result = BaseInvoke(() => Channel.GetRecentTracks(ApiKey, user, limit, page, extended, from, to));
            return result;
        }

        public XmlDocument GetArtistTracks(string user, string artist, int? page = null, DateTime? endTimestamp = null)
        {
            var result = BaseInvoke(() => Channel.GetArtistTracks(ApiKey, user, artist, page, endTimestamp.ConvertToTimestamp()));
            return result;
        }

        public XmlDocument GetBannedTracks(string user, int? limit = null, int? page = null)
        {
            var result = BaseInvoke(() => Channel.GetBannedTracks(ApiKey, user, limit, page));
            return result;
        }

        public XmlDocument GetEvents(string user, int? page = null, byte? festivalsonly = null, int? limit = null)
        {
            var result = BaseInvoke(() => Channel.GetEvents(ApiKey, user, page, festivalsonly, limit));
            return result;
        }

        public XmlDocument GetFriends(string user, int? page = null, byte? recenttracks = 0, int? limit = null)
        {
            var result = BaseInvoke(() => Channel.GetFriends(ApiKey, user, page, recenttracks, limit));
            return result;
        }

        public XmlDocument GetInfo(string user)
        {
            var result = BaseInvoke(() => Channel.GetInfo(ApiKey, user));
            return result;
        }

        public XmlDocument GetLovedTracks(string user, int? limit = null, int? page = null)
        {
            var result = BaseInvoke(() => Channel.GetLovedTracks(ApiKey, user, limit, page));
            return result;
        }

        public XmlDocument GetNeighbours(string user, int? limit = null)
        {
            var result = BaseInvoke(() => Channel.GetNeighbours(ApiKey, user, limit));
            return result;
        }

        public XmlDocument GetNewReleases(string user, byte? userecs = 0)
        {
            var result = BaseInvoke(() => Channel.GetNewReleases(ApiKey, user, userecs));
            return result;
        }

        public XmlDocument GetPastEvents(string user, int? limit = null, int? page = null)
        {
            var result = BaseInvoke(() => Channel.GetPastEvents(ApiKey, user, limit, page));
            return result;
        }

        public XmlDocument GetPersonalTags(string user, string tag, TaggingType taggingType, int? limit = null, int? page = null)
        {
            var result = BaseInvoke(() => Channel.GetPersonalTags(ApiKey, user, tag, taggingType.ToString().ToLower(), limit, page));
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
