//-----------------------------------------------------------------------
// <copyright file="EventArtists.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Serialization;

namespace Last.fm.API.User
{
    [XmlRoot("artists")]
    public class EventArtists
    {
        [XmlElement("artist")]
        public List<string> Artists { get; set; }

        [XmlElement("headliner")]
        public string Headliner { get; set; }

        #region

        public override string ToString()
        {
            return string.Format("Headliner: {0}",
                Headliner ?? string.Empty);
        }

        #endregion
    }
}