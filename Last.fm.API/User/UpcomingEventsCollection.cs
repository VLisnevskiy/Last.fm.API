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
    public class UpcomingEventsCollection : PageCollection<LfmEvent>
    {
        [XmlAttribute("user")]
        public string User { get; set; }

        [XmlAttribute("festivalsonly")]
        public bool FestivalsOnly { get; set; }

        #region BaseCollection implementation

        private List<LfmEvent> events = new List<LfmEvent>();

        [XmlAttribute("event")]
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
            FestivalsOnly = doc.Root.GetAttributeValue<bool>("festivalsonly");
            Collection = doc.Root.ExtracktItems<LfmEvent>("event");
        }

        #endregion
    }
}