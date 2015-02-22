//-----------------------------------------------------------------------
// <copyright file="TagsCollection.cs" company="Vyacheslav Lisnevskyi">
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
using Last.fm.API.Core.Types;

namespace Last.fm.API.User
{
    /// <summary>
    /// Tags collection.
    /// </summary>
    [XmlRoot("toptags")]
    public class TagsCollection : BaseResponse, ICollection<LfmTag>, IEnumerable, IXmlSerializable
    {
        [XmlAttribute("user")]
        public string User { get; set; }

        [XmlElement("tag")]
        public List<LfmTag> Tags { get; set; }

        public TagsCollection()
        {
            Tags = new List<LfmTag>();
        }

        #region ICollection<TagsCollection>, IEnumerable

        public void CopyTo(Array array, int index)
        {
            List<LfmTag> items = new List<LfmTag>();
            while (array.GetEnumerator().MoveNext())
            {
                LfmTag tag = array.GetEnumerator().Current as LfmTag;
                if (null != tag)
                {
                    items.Add(tag);
                }
            }

            Tags.CopyTo(items.ToArray(), index);
        }

        public int Count
        {
            get { return Tags.Count; }
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
            return Tags.GetEnumerator();
        }

        public LfmTag this[int index]
        {
            get
            {
                return Tags[index];
            }
            set
            {
                Tags[index] = value;
            }
        }

        public void Add(LfmTag item)
        {
            Tags.Add(item);
        }

        public void Clear()
        {
            Tags.Clear();
        }

        public bool Contains(LfmTag item)
        {
            return Tags.Contains(item);
        }

        public void CopyTo(LfmTag[] array, int arrayIndex)
        {
            Tags.CopyTo(array, arrayIndex);
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(LfmTag item)
        {
            return Tags.Remove(item);
        }

        IEnumerator<LfmTag> IEnumerable<LfmTag>.GetEnumerator()
        {
            return Tags.GetEnumerator();
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
                Tags = doc.Root.ExtracktItems<LfmTag>("tag");
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
            return string.Format("Top tags of {0}",
                User ?? string.Empty);
        }

        #endregion
    }
}