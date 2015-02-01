//-----------------------------------------------------------------------
// <copyright file="ArtistFormation.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace Last.fm.API.Artist
{
    /// <summary>
    /// Artist / Band fomation
    /// </summary>
    public class ArtistFormation
    {
        /// <summary>
        /// Year when was formed.
        /// </summary>
        [XmlElement("yearfrom")]
        public string YearFrom { get; set; }

        /// <summary>
        /// Where formed till.
        /// </summary>
        [XmlElement("yearto")]
        public string YearTo { get; set; }

        #region Overrided

        public override string ToString()
        {
            return string.Format("Was formed from [{0}] till [{1}]",
                YearFrom,
                YearTo);
        }

        #endregion
    }
}