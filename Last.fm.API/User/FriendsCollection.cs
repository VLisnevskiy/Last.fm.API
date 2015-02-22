//-----------------------------------------------------------------------
// <copyright file="FriendsCollection.cs" company="Vyacheslav Lisnevskyi">
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
    [XmlRoot("friends")]
    public class FriendsCollection : PageCollection<UserInfo>
    {
        [XmlElement("for")]
        public string For { get; set; }

        #region BaseCollection implementation

        private List<UserInfo> users = new List<UserInfo>();

        [XmlElement("user")]
        public override List<UserInfo> Collection
        {
            get { return users; }
            set { users = value; }
        }

        #endregion

        #region IXmlSerializable

        public override void ReadXml(XDocument doc)
        {
            base.ReadXml(doc);
            For = doc.Root.GetAttributeValue<string>("for");
            Collection = doc.Root.ExtracktItems<UserInfo>("user");
        }

        #endregion
    }
}