//-----------------------------------------------------------------------
// <copyright file="LfmLink.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace Last.fm.API.Core.Types
{
    /// <summary>
    /// LastFm link.
    /// </summary>
    public class LfmLink
    {
        /// <summary>
        /// Link url.
        /// </summary>
        [XmlAttribute("link")]
        public string Link { get; set; }

        #region Overrided

        public override string ToString()
        {
            return string.Format("Link - [{0}]", Link);
        }

        #endregion
    }
}