//-----------------------------------------------------------------------
// <copyright file="ArtistInfo.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Last.fm.API.Core;
using Last.fm.API.Core.Types;

namespace Last.fm.API.Artist
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [XmlRoot("artist")]
    public class ArtistInfo : BaseResponse
    {
        /// <summary>
        /// Constructor of ArtistInfo. Create new instance.
        /// </summary>
        public ArtistInfo()
        {
            Images = new List<LfmImage>();
            SimilarArtists = new List<SimilarArtist>();
            Tags = new List<LfmTag>();
        }

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

        /// <summary>
        /// mbid
        /// </summary>
        [XmlElement("mbid")]
        public Guid Mbid { get; set; }

        /// <summary>
        /// Streamable.
        /// </summary>
        [XmlElement("streamable")]
        public bool Streamable { get; set; }

        /// <summary>
        /// On tour
        /// </summary>
        [XmlElement("ontour")]
        public bool OnTour { get; set; }

        /// <summary>
        /// Artist status
        /// </summary>
        [XmlElement("stats")]
        public ArtistStatus Status { get; set; }

        /// <summary>
        /// Similar artists.
        /// </summary>
        [XmlArray("similar")]
        [XmlArrayItem("artist")]
        public List<SimilarArtist> SimilarArtists { get; set; }

        /// <summary>
        /// Artist tags.
        /// </summary>
        [XmlArray("tags")]
        [XmlArrayItem("tag")]
        public List<LfmTag> Tags { get; set; }

        /// <summary>
        /// Artist short biography
        /// </summary>
        [XmlElement("bio")]
        public ArtistBio Bio { get; set; }

        #region Overrided

        public override string ToString()
        {
            return string.Format("Artist - [{0}] - Url [{1}] - On tour [{2}]",
                Name,
                Url,
                OnTour);
        }

        #endregion
    }
}