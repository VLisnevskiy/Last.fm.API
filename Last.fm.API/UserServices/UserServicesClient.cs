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

        public UserServicesClient(string apiKey, string apiSig)
            : base(apiKey, apiSig)
        {
        }

        #region IUserServices methods

        public XmlDocument GetRecentTracks(string user, int? limit = null, int? page = null, byte? extended = null,
                                           double? from = 0, double? to = 0)
        {
            var result = Invoke(() => Channel.GetRecentTracks(ApiKey, user, limit, page, extended, from, to));
            return result;
        }

        public XmlDocument GetArtistTracks(string user, string artist, int? page = null, DateTime? endTimestamp = null)
        {
            var result = Invoke(() => Channel.GetArtistTracks(ApiKey, user, artist, page, endTimestamp.ConvertToTimestamp()));
            return result;
        }

        public XmlDocument GetBannedTracks(string user, int? limit = null, int? page = null)
        {
            var result = Invoke(() => Channel.GetBannedTracks(ApiKey, user, limit, page));
            return result;
        }

        public XmlDocument GetEvents(string user, int? page = null, byte? festivalsonly = null, int? limit = null)
        {
            var result = Invoke(() => Channel.GetEvents(ApiKey, user, page, festivalsonly, limit));
            return result;
        }

        public XmlDocument GetFriends(string user, int? page = null, byte? recenttracks = 0, int? limit = null)
        {
            var result = Invoke(() => Channel.GetFriends(ApiKey, user, page, recenttracks, limit));
            return result;
        }

        public XmlDocument GetInfo(string user)
        {
            var result = Invoke(() => Channel.GetInfo(ApiKey, user));
            return result;
        }

        public XmlDocument GetLovedTracks(string user, int? limit = null, int? page = null)
        {
            var result = Invoke(() => Channel.GetLovedTracks(ApiKey, user, limit, page));
            return result;
        }

        public XmlDocument GetNeighbours(string user, int? limit = null)
        {
            var result = Invoke(() => Channel.GetNeighbours(ApiKey, user, limit));
            return result;
        }

        public XmlDocument GetNewReleases(string user, byte? userecs = 0)
        {
            var result = Invoke(() => Channel.GetNewReleases(ApiKey, user, userecs));
            return result;
        }

        public XmlDocument GetPastEvents(string user, int? limit = null, int? page = null)
        {
            var result = Invoke(() => Channel.GetPastEvents(ApiKey, user, limit, page));
            return result;
        }

        public XmlDocument GetPersonalTags(string user, string tag, TaggingType taggingType, int? limit = null, int? page = null)
        {
            var result = Invoke(() => Channel.GetPersonalTags(ApiKey, user, tag, taggingType.ToString().ToLowerInvariant(), limit, page));
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
