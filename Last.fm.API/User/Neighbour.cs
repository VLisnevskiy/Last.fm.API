//-----------------------------------------------------------------------
// <copyright file="Neighbour.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Serialization;
using Last.fm.API.Core.Types;

namespace Last.fm.API.User
{
    [XmlRoot("user")]
    public class Neighbour
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("realname")]
        public string RealName { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("match")]
        public string Match { get; set; }

        [XmlElement("image")]
        public List<LfmImage> Images { get; set; }

        #region Overrided

        public override string ToString()
        {
            return string.Format("[{0}] - {1}",
                Name ?? string.Empty,
                RealName ?? string.Empty);
        }

        #endregion
    }
}