//-----------------------------------------------------------------------
// <copyright file="LfmDateTime.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace Last.fm.API.Core.Types
{
    /// <summary>
    /// Last.fm Date & Time value
    /// </summary>
    [XmlRoot("date")]
    public class LfmDateTime
    {
        /// <summary>
        /// Unix Date & Time
        /// </summary>
        [XmlAttribute("unixtime")]
        public long UnixTime { get; set; }

        /// <summary>
        /// Normal Date & Time
        /// </summary>
        [XmlText]
        public string DateTime { get; set; }

        #region Overrided

        public override string ToString()
        {
            return DateTime;
        }

        #endregion
    }
}