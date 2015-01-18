//-----------------------------------------------------------------------
// <copyright file="NowPlayingInfo.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Serialization;
using Last.fm.API.Core;
using Last.fm.API.Core.Types;

namespace Last.fm.API.Track
{
    /// <summary>
    /// Now playing track info
    /// </summary>
    [Serializable]
    [XmlRoot("nowplaying")]
    public class NowPlayingTrackInfo : BaseResponse
    {
        /// <summary>
        /// Trak title
        /// </summary>
        [XmlElement("track")]
        public LfmString Track { get; set; }

        /// <summary>
        /// Artist name
        /// </summary>
        [XmlElement("artist")]
        public LfmString Artist { get; set; }

        /// <summary>
        /// Album artist name
        /// </summary>
        [XmlElement("albumArtist")]
        public LfmString AlbumArtist { get; set; }

        /// <summary>
        /// Ignored message
        /// </summary>
        [XmlElement("ignoredMessage")]
        public ErrorMessage IgnoredMessage { get; set; }
    }
}
