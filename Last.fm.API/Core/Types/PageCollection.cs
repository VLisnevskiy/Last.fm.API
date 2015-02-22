//-----------------------------------------------------------------------
// <copyright file="PageCollection.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Linq;
using System.Xml.Serialization;

namespace Last.fm.API.Core.Types
{
    public abstract class PageCollection<TCollection> : BaseCollection<TCollection>
        where TCollection : class, new()
    {
        [XmlAttribute("page")]
        public virtual int Page { get; set; }

        [XmlAttribute("perPage")]
        public virtual int PearPage { get; set; }

        [XmlAttribute("totalPages")]
        public virtual int TotalPages { get; set; }

        [XmlAttribute("total")]
        public virtual int TotalCount { get; set; }

        #region IXmlSerializable

        public override void ReadXml(XDocument doc)
        {
            base.ReadXml(doc);
            Page = doc.Root.GetAttributeValue<int>("page");
            PearPage = doc.Root.GetAttributeValue<int>("perPage");
            TotalPages = doc.Root.GetAttributeValue<int>("totalPages");
            TotalCount = doc.Root.GetAttributeValue<int>("total");
        }

        #endregion
    }
}