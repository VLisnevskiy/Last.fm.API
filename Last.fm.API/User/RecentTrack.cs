//-----------------------------------------------------------------------
// <copyright file="RecentTrack.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using Last.fm.API.Core;
using Last.fm.API.Core.Types;

namespace Last.fm.API.User
{
    [XmlRoot("recenttrack")]
    public class RecentTrack : LikeObject, IXmlSerializable
    {
        [XmlAttribute("date")]
        public string Date { get; set; }

        [XmlAttribute("uts")]
        public string UnixDate { get; set; }

        [XmlElement("artist")]
        public LfmShortArtistInfo Artist { get; set; }

        [XmlElement("album")]
        public LfmShortAlbumInfo Album { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("mbid")]
        public Guid Mbid { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        #region IXmlSerializable

        public override void ReadXml(XDocument doc)
        {
            if (null != doc.Root)
            {
                Date = doc.Root.GetAttributeValue<string>("date");
                UnixDate = doc.Root.GetAttributeValue<string>("uts");
                Name = doc.Root.GetValue<string>("name");
                Mbid = doc.Root.GetValue<Guid>("mbid");
                Url = doc.Root.GetValue<string>("url");
                Artist = new LfmShortArtistInfo();
                XElement element = doc.Root.Element("artist");
                if (null != element)
                {
                    Artist.Name = element.GetValue<string>("name");
                    Artist.Mbid = element.GetValue<Guid>("mbid");
                    Artist.Url = element.GetValue<string>("url");
                }

                Album = new LfmShortAlbumInfo();
                element = doc.Root.Element("album");
                if (null != element)
                {
                    Album.Name = element.GetValue<string>("name");
                    Album.Mbid = element.GetValue<Guid>("mbid");
                    Album.Url = element.GetValue<string>("url");
                }
            }
        }

        #endregion

        #region Overrided

        public override string ToString()
        {
            return string.Format("{0} - {1}",
                Artist ?? new LfmShortArtistInfo {Name = string.Empty},
                Name ?? string.Empty);
        }

        #endregion
    }
}