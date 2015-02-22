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
    [XmlRoot("lovedtracks")]
    public class LovedTracksCollection : PageCollection<LfmTrack>
    {
        [XmlAttribute("user")]
        public string User { get; set; }

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
            Collection = doc.Root.ExtracktItems<LfmTrack>("track");
        }

        #endregion
    }
}