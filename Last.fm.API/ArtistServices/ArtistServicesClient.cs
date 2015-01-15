using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Last.fm.API.BaseLastFm;

namespace Last.fm.API.ArtistServices
{
    internal class ArtistServicesClient : BaseLastFmClient<IArtistServicesApi>, IArtistServices
    {
        public ArtistServicesClient(string apiKey, string apiSig)
            : base(apiKey, apiSig)
        {
        }

        public ArtistInfo GetInfo(string artist, string username = null, string mbid = null, string lang = null, bool autocorrect = true)
        {
            var result = Invoke(() => Channel.GetInfo(ApiKey, artist, username, mbid, lang, autocorrect));
            return result;
        }

        #region IDisposable

        ~ArtistServicesClient()
        {
            Dispose(false);
        }

        #endregion
    }
}
