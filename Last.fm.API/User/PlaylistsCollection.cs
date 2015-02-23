//-----------------------------------------------------------------------
// <copyright file="PlaylistsCollection.cs" company="Vyacheslav Lisnevskyi">
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
    /// Last.fm playlists collection.
    /// </summary>
    [XmlRoot("playlists")]
    public class PlaylistsCollection : BaseCollection<Playlist>
    {
        [XmlAttribute("user")]
        public string User { get; set; }

        #region BaseCollection implementation

        private List<Playlist> playlists = new List<Playlist>();

        [XmlElement("playlist")]
        public override List<Playlist> Collection
        {
            get { return playlists; }
            set { playlists = value; }
        }

        #endregion

        #region IXmlSerializable

        public override void ReadXml(XDocument doc)
        {
            base.ReadXml(doc);
            User = doc.Root.GetAttributeValue<string>("user");
            Collection = doc.Root.ExtracktItems<Playlist>("playlist");
        }

        #endregion
    }
}