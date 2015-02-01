//-----------------------------------------------------------------------
// <copyright file="ArtistStatus.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace Last.fm.API.Artist
{
    /// <summary>
    /// Artist status
    /// </summary>
    public class ArtistStatus
    {
        /// <summary>
        /// Count of listeners.
        /// </summary>
        [XmlElement("listeners")]
        public int Listeners { get; set; }

        /// <summary>
        /// Count of playcount.
        /// </summary>
        [XmlElement("playcount")]
        public int Playcount { get; set; }

        public override string ToString()
        {
            return string.Format("Listeners: [{0}] - Playcount: [{1}]", Listeners, Playcount);
        }
    }
}