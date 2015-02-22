//-----------------------------------------------------------------------
// <copyright file="RecentTracksCollection.cs" company="Vyacheslav Lisnevskyi">
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
    [XmlRoot("recenttracks")]
    public class RecentTracksCollection : PageCollection<LfmTrack>
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

        #region Overrided

        public override string ToString()
        {
            return string.Format("User : {0} [{1} of {3} - {2} pear page] (Total count : {4})",
                User ?? string.Empty,
                Page,
                PearPage,
                TotalPages,
                TotalCount);
        }

        #endregion
    }
}
