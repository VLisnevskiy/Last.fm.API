//-----------------------------------------------------------------------
// <copyright file="UpcomingEventsCollection.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
using Last.fm.API.Core;
using Last.fm.API.Core.Types;

namespace Last.fm.API.User
{
    [XmlRoot("events")]
    public class UpcomingEventsCollection : BaseCollection<UpcomingEvent>
    {
        [XmlAttribute("user")]
        public string User { get; set; }

        [XmlAttribute("festivalsonly")]
        public bool FestivalsOnly { get; set; }

        #region BaseCollection implementation

        private List<UpcomingEvent> upcomingEvents = new List<UpcomingEvent>();

        [XmlAttribute("event")]
        public override List<UpcomingEvent> Collection
        {
            get { return upcomingEvents; }
            set { upcomingEvents = value; }
        }

        #endregion

        #region IXmlSerializable

        public override void ReadXml(XDocument doc)
        {
            base.ReadXml(doc);
            User = doc.Root.GetAttributeValue<string>("user");
            FestivalsOnly = doc.Root.GetAttributeValue<bool>("festivalsonly");
            Collection = doc.Root.ExtracktItems<UpcomingEvent>("event");
        }

        #endregion
    }
}