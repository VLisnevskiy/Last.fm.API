//-----------------------------------------------------------------------
// <copyright file="RecentTracksCollection.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Last.fm.API.Core;

namespace Last.fm.API.User
{
    [XmlRoot("recenttracks")]
    public class RecentTracksCollection : BaseResponse, ICollection<RecentTrack>, IEnumerable, IXmlSerializable
    {
        public RecentTracksCollection()
        {
            RecentTracks = new List<RecentTrack>();
        }

        [XmlAttribute("user")]
        public string User { get; set; }

        [XmlAttribute("page")]
        public int Page { get; set; }

        [XmlAttribute("perPage")]
        public int PearPage { get; set; }

        [XmlAttribute("totalPages")]
        public int TotalPages { get; set; }

        [XmlAttribute("total")]
        public int TotalTracksCount { get; set; }

        [XmlElement("track")]
        public List<RecentTrack> RecentTracks { get; set; }

        #region ICollection<RecentTrack>, IEnumerable

        public void CopyTo(Array array, int index)
        {
            List<RecentTrack> items = new List<RecentTrack>();
            while (array.GetEnumerator().MoveNext())
            {
                RecentTrack recentTrack = array.GetEnumerator().Current as RecentTrack;
                if (null != recentTrack)
                {
                    items.Add(recentTrack);
                }
            }

            RecentTracks.CopyTo(items.ToArray(), index);
        }

        public int Count
        {
            get { return RecentTracks.Count; }
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
            return RecentTracks.GetEnumerator();
        }

        public RecentTrack this[int index]
        {
            get
            {
                return RecentTracks[index];
            }
            set
            {
                RecentTracks[index] = value;
            }
        }

        public void Add(RecentTrack item)
        {
            RecentTracks.Add(item);
        }

        public void Clear()
        {
            RecentTracks.Clear();
        }

        public bool Contains(RecentTrack item)
        {
            return RecentTracks.Contains(item);
        }

        public void CopyTo(RecentTrack[] array, int arrayIndex)
        {
            RecentTracks.CopyTo(array, arrayIndex);
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(RecentTrack item)
        {
            return RecentTracks.Remove(item);
        }

        IEnumerator<RecentTrack> IEnumerable<RecentTrack>.GetEnumerator()
        {
            return RecentTracks.GetEnumerator();
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
                XElement rootElement = doc.Root;
                XAttribute attribute = rootElement.Attribute("user");
                if (null != attribute)
                {
                    User = attribute.Value;
                }
                attribute = rootElement.Attribute("page");
                if (null != attribute)
                {
                    Page = int.Parse(attribute.Value);
                }
                attribute = rootElement.Attribute("perPage");
                if (null != attribute)
                {
                    PearPage = int.Parse(attribute.Value);
                }
                attribute = rootElement.Attribute("totalPages");
                if (null != attribute)
                {
                    TotalPages = int.Parse(attribute.Value);
                }
                attribute = rootElement.Attribute("total");
                if (null != attribute)
                {
                    TotalTracksCount = int.Parse(attribute.Value);
                }

                XmlSerializer serializer = new XmlSerializer(typeof(RecentTrack));
                foreach (XElement element in rootElement.Elements("track"))
                {
                    using (Stream stream = new MemoryStream())
                    {
                        element.Save(stream);
                        stream.Position = 0;
                        RecentTrack recentTrack = serializer.Deserialize(stream) as RecentTrack;
                        if (null != recentTrack)
                        {
                            RecentTracks.Add(recentTrack);
                        }
                    }
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            XDocument doc = new XDocument();
            doc.Save(writer);
        }

        #endregion

        #region Overrided

        public override string ToString()
        {
            return string.Format("User : {0} [{1} of {3} - {2} pear page] (Total count : {4})",
                User,
                Page,
                PearPage,
                TotalPages,
                TotalTracksCount);
        }

        #endregion
    }
}
