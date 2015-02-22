//-----------------------------------------------------------------------
// <copyright file="LfmTag.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace Last.fm.API.Core.Types
{
    /// <summary>
    /// LastFm tag
    /// </summary>
    [XmlRoot("tag")]
    public class LfmTag
    {
        /// <summary>
        /// Tag name
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Url on tag
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }

        /// <summary>
        /// Count.
        /// </summary>
        [XmlElement("count")]
        public int Count { get; set; }

        public override string ToString()
        {
            return string.Format("Tag name: [{0}] - Url [{1}]", Name, Url);
        }
    }
}