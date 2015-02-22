//-----------------------------------------------------------------------
// <copyright file="Venue.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Serialization;
using Last.fm.API.Core.Types;

namespace Last.fm.API.User
{
    [XmlRoot("venue")]
    public class Venue
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("website")]
        public string WebSite { get; set; }

        [XmlElement("phonenumber")]
        public string PhoneNumber { get; set; }

        [XmlElement("image")]
        public List<LfmImage> Images { get; set; }

        [XmlElement("location")]
        public Location Location { get; set; }

        #region Overrided

        public override string ToString()
        {
            return string.Format("Venue: {0} - Id: {1}",
                Name ?? string.Empty,
                Id);
        }

        #endregion
    }
}