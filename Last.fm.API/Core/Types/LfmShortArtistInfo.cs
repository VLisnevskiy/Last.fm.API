//-----------------------------------------------------------------------
// <copyright file="LfmShortArtistInfo.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Last.fm.API.Core.Types
{
    /// <summary>
    /// LastFm short artist info.
    /// </summary>
    [XmlRoot("artist")]
    public class LfmShortArtistInfo
    {
        public LfmShortArtistInfo()
        {
            Images = new List<LfmImage>();
        }

        /// <summary>
        /// Mbid.
        /// </summary>
        [XmlAttribute("mbid")]
        public Guid Mbid { get; set; }

        /// <summary>
        /// Artist name.
        /// </summary>
        [XmlText]
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Url.
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }

        /// <summary>
        /// Images
        /// </summary>
        public List<LfmImage> Images { get; set; }

        #region Overrided

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}