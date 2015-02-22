//-----------------------------------------------------------------------
// <copyright file="ArtistTracksCollection.cs" company="Vyacheslav Lisnevskyi">
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
    /// <summary>
    /// Artist tracks collection.
    /// </summary>
    [XmlRoot("artisttracks")]
    public class ArtistTracksCollection : BaseResponse, ICollection<Track>, IEnumerable, IXmlSerializable
    {
        public ArtistTracksCollection()
        {
            Tracks = new List<Track>();
        }

        [XmlElement("track")]
        public List<Track> Tracks { get; set; }

        [XmlAttribute("user")]
        public string User { get; set; }

        [XmlAttribute("artist")]
        public string Artist { get; set; }

        [XmlAttribute("items")]
        public int Amount { get; set; }

        [XmlElement("page")]
        public int Page { get; set; }

        [XmlAttribute("perPage")]
        public int PearPage { get; set; }

        [XmlAttribute("totalPages")]
        public int TotalPages { get; set; }

        [XmlAttribute("total")]
        public int TotalTracksCount { get; set; }

        #region ICollection<Track>, IEnumerable

        public void CopyTo(Array array, int index)
        {
            List<Track> items = new List<Track>();
            while (array.GetEnumerator().MoveNext())
            {
                Track recentTrack = array.GetEnumerator().Current as Track;
                if (null != recentTrack)
                {
                    items.Add(recentTrack);
                }
            }

            Tracks.CopyTo(items.ToArray(), index);
        }

        public int Count
        {
            get { return Tracks.Count; }
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
            return Tracks.GetEnumerator();
        }

        public Track this[int index]
        {
            get
            {
                return Tracks[index];
            }
            set
            {
                Tracks[index] = value;
            }
        }

        public void Add(Track item)
        {
            Tracks.Add(item);
        }

        public void Clear()
        {
            Tracks.Clear();
        }

        public bool Contains(Track item)
        {
            return Tracks.Contains(item);
        }

        public void CopyTo(Track[] array, int arrayIndex)
        {
            Tracks.CopyTo(array, arrayIndex);
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Track item)
        {
            return Tracks.Remove(item);
        }

        IEnumerator<Track> IEnumerable<Track>.GetEnumerator()
        {
            return Tracks.GetEnumerator();
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
                Artist = doc.Root.GetAttributeValue<string>("artist");
                Amount = doc.Root.GetAttributeValue<int>("items");
                Page = doc.Root.GetAttributeValue<int>("page");
                PearPage = doc.Root.GetAttributeValue<int>("perPage");
                TotalPages = doc.Root.GetAttributeValue<int>("totalPages");
                TotalTracksCount = doc.Root.GetAttributeValue<int>("total");
                Tracks = doc.Root.ExtracktItems<Track>("track");
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