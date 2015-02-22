//-----------------------------------------------------------------------
// <copyright file="NeighboursCollection.cs" company="Vyacheslav Lisnevskyi">
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
    [XmlRoot("neighbours")]
    public class NeighboursCollection : BaseCollection<Neighbour>
    {
        [XmlAttribute("user")]
        public string User { get; set; }

        #region BaseCollection implementation

        private List<Neighbour> neighbours = new List<Neighbour>();

        [XmlElement("user")]
        public override List<Neighbour> Collection
        {
            get { return neighbours; }
            set { neighbours = value; }
        }

        #endregion

        #region IXmlSerializable

        public override void ReadXml(XDocument doc)
        {
            base.ReadXml(doc);
            User = doc.Root.GetAttributeValue<string>("user");
            Collection = doc.Root.ExtracktItems<Neighbour>("user");
        }

        #endregion
    }
}