﻿using System.ServiceModel;
using System.ServiceModel.Web;
using Last.fm.API.AuthServices;
using Last.fm.API.BaseLastFm;

namespace Last.fm.API.TrackServices
{
    [ServiceContract]
    [XmlSerializerFormat]
    internal interface ITrackServicesApi : IApiKeys
    {
        /*

    track.addTags
    track.ban
    track.getBuylinks
    track.getCorrection
    track.getFingerprintMetadata
    track.getInfo
    track.getShouts
    track.getSimilar
    track.getTags
    track.getTopFans
    track.getTopTags
    track.love
    track.removeTag
    track.scrobble
    track.search
    track.share
    track.unban
    track.unlove*/

    #region track.updateNowPlaying

        /*
         * artist (Required) : The artist name.
         * track (Required) : The track name.
         * album (Optional) : The album name.
         * trackNumber (Optional) : The track number of the track on the album.
         * context (Optional) : Sub-client version (not public, only enabled for certain API keys)
         * mbid (Optional) : The MusicBrainz Track ID.
         * duration (Optional) : The length of the track in seconds.
         * albumArtist (Optional) : The album artist - if this differs from the track artist.
         * api_key (Required) : A Last.fm API key.
         * api_sig (Required) : A Last.fm method signature. See authentication for more information.
         * sk (Required) : A session key generated by authenticating a user via the authentication protocol.
         */
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "?method=track.updateNowPlaying&api_key={apiKey}&api_sig={apiSig}&sk={sk}&artist={artist}&, string track, string album = null, string albumArtist = null, long? duration = null, string trackNumber = null, string mbid")]
        AuthSession UpdateNowPlaying(string apiKey, string apiSig, string sk, string artist, string track, string album = null, string albumArtist = null, long? duration = null, string trackNumber = null, string mbid = null);

    #endregion

    }
}
