//-----------------------------------------------------------------------
// <copyright file="SimilarArtist.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Serialization;
using Last.fm.API.Core.Types;

namespace Last.fm.API.Artist
{
    /// <summary>
    /// Similar artist
    /// </summary>
    public class SimilarArtist
    {
        /// <summary>
        /// Artist Name.
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Artist images.
        /// </summary>
        [XmlElement("image")]
        public List<LfmImage> Images { get; set; }

        /// <summary>
        /// Url on artist page.
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }

        #region Overrided

        public override string ToString()
        {
            return string.Format("Artist - [{0}] - Url [{1}]", Name, Url);
        }

        #endregion
    }
}