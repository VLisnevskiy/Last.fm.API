﻿//-----------------------------------------------------------------------
// <copyright file="Track.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Last.fm.API.Core;
using Last.fm.API.Core.Types;

namespace Last.fm.API.User
{
    /// <summary>
    /// LastFm track.
    /// </summary>
    [XmlRoot("track")]
    public class Track : LikeObject, IXmlSerializable
    {
        public Track()
        {
            Images = new List<LfmImage>();
        }

        [XmlElement("artist")]
        public LfmShortArtistInfo Artist { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("streamable")]
        public bool Streamable { get; set; }

        [XmlElement("mbid")]
        public Guid Mbid { get; set; }

        [XmlElement("album")]
        public LfmShortAlbumInfo Album { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("image")]
        public List<LfmImage> Images { get; set; }

        [XmlElement("date")]
        public LfmDateTime DateTime { get; set; }

        [XmlElement("loved")]
        public bool Loved { get; set; }

        #region IXmlSerializable

        public override void ReadXml(XDocument doc)
        {
            if (null != doc.Root)
            {
                XElement element = doc.Root.Element("artist");
                if (null != element)
                {
                    Artist = new LfmShortArtistInfo();
                    if (element.Elements().ToList().Count > 1)
                    {
                        Artist.Name = element.GetValue<string>("name");
                        Artist.Mbid = element.GetValue<Guid>("mbid");
                        Artist.Images = element.ExtracktItems<LfmImage>("image");
                        Loved = element.GetValue<bool>("loved");
                    }
                    else
                    {
                        Artist.Name = element.Value;
                        Artist.Mbid = element.GetAttributeValue<Guid>("mbid");
                    }
                }

                Name = doc.Root.GetValue<string>("name");
                Streamable = doc.Root.GetValue<bool>("streamable");
                Mbid = doc.Root.GetValue<Guid>("mbid");
                element = doc.Root.Element("album");
                if (null != element)
                {
                    Album = new LfmShortAlbumInfo();
                    Album.Name = element.Value;
                    Album.Mbid = element.GetAttributeValue<Guid>("mbid");
                }

                Url = doc.Root.GetValue<string>("url");
                element = doc.Root.Element("date");
                if (null != element)
                {
                    DateTime = new LfmDateTime();
                    DateTime.DateTime = element.Value;
                    DateTime.UnixTime = element.GetAttributeValue<long>("uts");
                }

                Images = doc.Root.ExtracktItems<LfmImage>("image");
            }
        }

        #endregion

        #region Overrided

        public override string ToString()
        {
            return string.Format("{0} - {1} [{2}]",
                Artist ?? new LfmShortArtistInfo { Name = "" },
                Name ?? string.Empty,
                DateTime ?? new LfmDateTime { DateTime = "" });
        }

        #endregion
    }
}
