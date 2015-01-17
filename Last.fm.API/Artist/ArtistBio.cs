//-----------------------------------------------------------------------
// <copyright file="ArtistBio.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Serialization;
using Last.fm.API.Core.Types;

namespace Last.fm.API.Artist
{
    /// <summary>
    /// Artist short biography
    /// </summary>
    public class ArtistBio
    {
        /// <summary>
        /// Constructor of ArtistBio. Create new instance.
        /// </summary>
        public ArtistBio()
        {
            Links = new List<LfmLink>();
            Formations = new List<ArtistFormation>();
        }

        /// <summary>
        /// Links on artis biography.
        /// </summary>
        [XmlArray("links")]
        [XmlArrayItem("link")]
        public List<LfmLink> Links { get; set; }

        /// <summary>
        /// Published Date & Time.
        /// </summary>
        [XmlElement("published")]
        public string Published { get; set; }

        /// <summary>
        /// Summary.
        /// </summary>
        [XmlElement("summary")]
        public string Summary { get; set; }

        /// <summary>
        /// Content.
        /// </summary>
        [XmlElement("content")]
        public string Content { get; set; }

        /// <summary>
        /// Place where was formed.
        /// </summary>
        [XmlElement("placeformed")]
        public string PlaceWhereWasFormed { get; set; }

        /// <summary>
        /// Year when was formed.
        /// </summary>
        [XmlElement("yearformed")]
        public string YearWhenWasFormed { get; set; }

        /// <summary>
        /// Artist / Band formations
        /// </summary>
        [XmlArray("formationlist")]
        [XmlArrayItem("formation")]
        public List<ArtistFormation> Formations { get; set; }

        #region Overrided

        public override string ToString()
        {
            return string.Format("Was formed in [{0}] in [{1}]", YearWhenWasFormed, PlaceWhereWasFormed);
        }

        #endregion
    }
}