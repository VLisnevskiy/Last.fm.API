//-----------------------------------------------------------------------
// <copyright file="LfmTag.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace Last.fm.API.Core.Types
{
    /// <summary>
    /// LastFm tag
    /// </summary>
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

        public override string ToString()
        {
            return string.Format("Tag name: [{0}] - Url [{1}]", Name, Url);
        }
    }
}