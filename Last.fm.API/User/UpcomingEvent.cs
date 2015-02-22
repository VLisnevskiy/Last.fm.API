//-----------------------------------------------------------------------
// <copyright file="UpcomingEvent.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Serialization;
using Last.fm.API.Core.Types;

namespace Last.fm.API.User
{
    /// <summary>
    /// Upcoming event.
    /// </summary>
    [XmlRoot("event")]
    public class UpcomingEvent
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlAttribute("status")]
        public int Status { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("artists")]
        public EventArtists EventArtists { get; set; }

        [XmlElement("venue")]
        public Venue Venue { get; set; }

        [XmlElement("startDate")]
        public string StartDate { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("image")]
        public List<LfmImage> Images { get; set; }

        [XmlElement("attendance")]
        public bool Attendance { get; set; }

        [XmlElement("reviews")]
        public int Reviews { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("tag")]
        public string Tag { get; set; }

        [XmlElement("website")]
        public string WebSite { get; set; }

        [XmlArray("tickets")]
        [XmlArrayItem("ticket")]
        public List<Ticket> Tickets { get; set; }

        [XmlElement("cancelled")]
        public bool Cancelled { get; set; }

        #region

        public override string ToString()
        {
            return string.Format("Id: {0} - Title: {1}",
                Id,
                Title ?? string.Empty);
        }

        #endregion
    }
}