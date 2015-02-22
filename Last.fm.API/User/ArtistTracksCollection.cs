//-----------------------------------------------------------------------
// <copyright file="ArtistTracksCollection.cs" company="Vyacheslav Lisnevskyi">
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
    /// Artist tracks collection.
    /// </summary>
    [XmlRoot("artisttracks")]
    public class ArtistTracksCollection : PageCollection<LfmTrack>
    {
        [XmlAttribute("user")]
        public string User { get; set; }

        [XmlAttribute("artist")]
        public string Artist { get; set; }

        [XmlAttribute("items")]
        public int Amount { get; set; }

        #region BaseCollection implementation

        private List<LfmTrack> tracks = new List<LfmTrack>();

        [XmlElement("track")]
        public override List<LfmTrack> Collection
        {
            get { return tracks; }
            set { tracks = value; }
        }

        #endregion

        #region IXmlSerializable

        public override void ReadXml(XDocument doc)
        {
            base.ReadXml(doc);
            User = doc.Root.GetAttributeValue<string>("user");
            Artist = doc.Root.GetAttributeValue<string>("artist");
            Amount = doc.Root.GetAttributeValue<int>("items");
            Collection = doc.Root.ExtracktItems<LfmTrack>("track");
        }

        #endregion
    }
}