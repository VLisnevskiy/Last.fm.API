//-----------------------------------------------------------------------
// <copyright file="LfmShortAlbumInfo.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Serialization;

namespace Last.fm.API.Core.Types
{
    /// <summary>
    /// LastFm short album information.
    /// </summary>
    public class LfmShortAlbumInfo
    {
        /// <summary>
        /// Mbid.
        /// </summary>
        [XmlAttribute("mbid")]
        public Guid Mbid { get; set; }

        /// <summary>
        /// Album name.
        /// </summary>
        [XmlText]
        public string Name { get; set; }

        /// <summary>
        /// Url.
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }

        #region Overrided

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}