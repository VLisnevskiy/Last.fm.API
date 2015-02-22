//-----------------------------------------------------------------------
// <copyright file="TagsCollection.cs" company="Vyacheslav Lisnevskyi">
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
    /// <summary>
    /// Tags collection.
    /// </summary>
    [XmlRoot("toptags")]
    public class TagsCollection : PageCollection<LfmTag>
    {
        [XmlAttribute("user")]
        public string User { get; set; }

        #region BaseCollection implementation

        private List<LfmTag> tags = new List<LfmTag>();

        [XmlElement("tag")]
        public override List<LfmTag> Collection
        {
            get { return tags; }
            set { tags = value; }
        }

        #endregion

        #region IXmlSerializable

        public override void ReadXml(XDocument doc)
        {
            base.ReadXml(doc);
            User = doc.Root.GetAttributeValue<string>("user");
            Collection = doc.Root.ExtracktItems<LfmTag>("tag");
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