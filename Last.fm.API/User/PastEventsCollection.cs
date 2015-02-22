//-----------------------------------------------------------------------
// <copyright file="PastEventsCollection.cs" company="Vyacheslav Lisnevskyi">
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
    public class PastEventsCollection : PageCollection<LfmEvent>
    {
        [XmlAttribute("user")]
        public string User { get; set; }

        [XmlAttribute("url")]
        public string Url { get; set; }

        [XmlAttribute("usertimezone")]
        public string UserTimeZone { get; set; }

        #region BaseCollection implementation

        private List<LfmEvent> events = new List<LfmEvent>();

        [XmlElement("event")]
        public override List<LfmEvent> Collection
        {
            get { return events; }
            set { events = value; }
        }

        #endregion

        #region IXmlSerializable

        public override void ReadXml(XDocument doc)
        {
            base.ReadXml(doc);
            User = doc.Root.GetAttributeValue<string>("user");
            Url = doc.Root.GetAttributeValue<string>("url");
            UserTimeZone = doc.Root.GetAttributeValue<string>("usertimezone");
            Collection = doc.Root.ExtracktItems<LfmEvent>("event");
        }

        #endregion
    }
}