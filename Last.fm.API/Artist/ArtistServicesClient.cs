//-----------------------------------------------------------------------
// <copyright file="ArtistServicesClient.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Last.fm.API.Core;

namespace Last.fm.API.Artist
{
    internal class ArtistServicesClient : BaseLastFmClient<IArtistServicesApi>, IArtistServices
    {
        #region IArtistServices

        public ArtistInfo GetInfo(string artist, string username = null, string mbid = null, string lang = null, bool autocorrect = true)
        {
            var result = Channel.GetInfo(ApiKey, artist, username, mbid, lang, autocorrect);

            return result;
        }

        #endregion

        #region IDisposable

        ~ArtistServicesClient()
        {
            Dispose(false);
        }

        #endregion
    }
}
