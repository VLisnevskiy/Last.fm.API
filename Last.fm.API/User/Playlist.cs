//-----------------------------------------------------------------------
// <copyright file="Playlist.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Serialization;
using Last.fm.API.Core.Types;

namespace Last.fm.API.User
{
    /// <summary>
    /// Last.fm playlist.
    /// </summary>
    [XmlRoot("playlist")]
    public class Playlist
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("date")]
        public LfmDateTime Date { get; set; }

        [XmlElement("size")]
        public int Size { get; set; }

        [XmlElement("duration")]
        public int Duration { get; set; }

        [XmlElement("streamable")]
        public Streamable Streamable { get; set; }

        [XmlElement("creator")]
        public string Creator { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("image")]
        public List<LfmImage> Images { get; set; }
    }
}