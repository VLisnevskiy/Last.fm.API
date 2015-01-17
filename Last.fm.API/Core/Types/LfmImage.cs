//-----------------------------------------------------------------------
// <copyright file="LfmImage.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace Last.fm.API.Core.Types
{
    /// <summary>
    /// LastFm image object
    /// </summary>
    public class LfmImage
    {
        /// <summary>
        /// Image size.
        /// </summary>
        [XmlAttribute("size")]
        public ImageSize Size { get; set; }

        /// <summary>
        /// Url on image.
        /// </summary>
        [XmlText]
        public string Url { get; set; }

        #region Overrided

        public override string ToString()
        {
            return string.Format("Image size [{0}] - Url: [{1}]",
                Size,
                Url);
        }

        #endregion
    }
}