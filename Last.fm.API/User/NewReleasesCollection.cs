//-----------------------------------------------------------------------
// <copyright file="NewReleasesCollection.cs" company="Vyacheslav Lisnevskyi">
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
    [XmlRoot("albums")]
    public class NewReleasesCollection : BaseCollection<AlbumRelease>
    {
        [XmlAttribute("user")]
        public string User { get; set; }

        [XmlAttribute("source")]
        public string Source { get; set; }

        #region BaseCollection implementation

        private List<AlbumRelease> albums = new List<AlbumRelease>();

        [XmlElement("album")]
        public override List<AlbumRelease> Collection
        {
            get { return albums; }
            set { albums = value; }
        }

        #endregion

        #region IXmlSerializable

        public override void ReadXml(XDocument doc)
        {
            base.ReadXml(doc);
            User = doc.Root.GetAttributeValue<string>("user");
            Source = doc.Root.GetAttributeValue<string>("source");
            Collection = doc.Root.ExtracktItems<AlbumRelease>("album");
        }

        #endregion
    }
}