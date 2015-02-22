//-----------------------------------------------------------------------
// <copyright file="AlbumRelease.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Serialization;
using Last.fm.API.Core.Types;

namespace Last.fm.API.User
{
    [XmlRoot("album")]
    public class AlbumRelease
    {
        [XmlAttribute("releasedate")]
        public string ReleaseDate { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("mbid")]
        public string Mbid { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("artist")]
        public LfmShortArtistInfo Artist { get; set; }

        [XmlElement("image")]
        public List<LfmImage> Images { get; set; }
    }
}