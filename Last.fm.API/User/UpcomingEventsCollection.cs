//-----------------------------------------------------------------------
// <copyright file="UpcomingEventsCollection.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Last.fm.API.Core;

namespace Last.fm.API.User
{
    [XmlRoot("events")]
    public class UpcomingEventsCollection : BaseResponse, ICollection<UpcomingEvent>, IEnumerable, IXmlSerializable
    {
        public UpcomingEventsCollection()
        {
            UpcomingEvents= new List<UpcomingEvent>();
        }

        [XmlAttribute("event")]
        public List<UpcomingEvent> UpcomingEvents { get; set; }

        [XmlAttribute("user")]
        public string User { get; set; }

        [XmlElement("page")]
        public int Page { get; set; }

        [XmlAttribute("perPage")]
        public int PearPage { get; set; }

        [XmlAttribute("totalPages")]
        public int TotalPages { get; set; }

        [XmlAttribute("total")]
        public int TotalEventsCount { get; set; }

        [XmlAttribute("festivalsonly")]
        public bool FestivalsOnly { get; set; }

        #region ICollection<UpcomingEvent>, IEnumerable

        public void CopyTo(Array array, int index)
        {
            List<UpcomingEvent> items = new List<UpcomingEvent>();
            while (array.GetEnumerator().MoveNext())
            {
                UpcomingEvent @event = array.GetEnumerator().Current as UpcomingEvent;
                if (null != @event)
                {
                    items.Add(@event);
                }
            }

            UpcomingEvents.CopyTo(items.ToArray(), index);
        }

        public int Count
        {
            get { return UpcomingEvents.Count; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return false; }
        }

        public IEnumerator GetEnumerator()
        {
            return UpcomingEvents.GetEnumerator();
        }

        public UpcomingEvent this[int index]
        {
            get
            {
                return UpcomingEvents[index];
            }
            set
            {
                UpcomingEvents[index] = value;
            }
        }

        public void Add(UpcomingEvent item)
        {
            UpcomingEvents.Add(item);
        }

        public void Clear()
        {
            UpcomingEvents.Clear();
        }

        public bool Contains(UpcomingEvent item)
        {
            return UpcomingEvents.Contains(item);
        }

        public void CopyTo(UpcomingEvent[] array, int arrayIndex)
        {
            UpcomingEvents.CopyTo(array, arrayIndex);
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(UpcomingEvent item)
        {
            return UpcomingEvents.Remove(item);
        }

        IEnumerator<UpcomingEvent> IEnumerable<UpcomingEvent>.GetEnumerator()
        {
            return UpcomingEvents.GetEnumerator();
        }

        #endregion

        #region IXmlSerializable

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XDocument doc = XDocument.Load(reader);
            if (null != doc.Root)
            {
                User = doc.Root.GetAttributeValue<string>("user");
                Page = doc.Root.GetAttributeValue<int>("page");
                PearPage = doc.Root.GetAttributeValue<int>("perPage");
                TotalPages = doc.Root.GetAttributeValue<int>("totalPages");
                TotalEventsCount = doc.Root.GetAttributeValue<int>("total");
                FestivalsOnly = doc.Root.GetAttributeValue<bool>("festivalsonly");
                UpcomingEvents = doc.Root.ExtracktItems<UpcomingEvent>("event");
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            XDocument doc = new XDocument();
            doc.Save(writer);
        }

        #endregion
    }
}