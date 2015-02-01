//-----------------------------------------------------------------------
// <copyright file="RecentTrack.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Last.fm.API.Core.Types;

namespace Last.fm.API.User
{
    /// <summary>
    /// LastFm reent track.
    /// </summary>
    [XmlRoot("track")]
    public class RecentTrack : IXmlSerializable
    {
        public RecentTrack()
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

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        /*<artist>
         * <name>Black Star</name>
         * <mbid>02708fd6-0fe6-4738-a27d-0561ace8b4c6</mbid>
         * <url>Black Star</url>
         * <image size="small">http://userserve-ak.last.fm/serve/34/73929612.png</image><image size="medium">http://userserve-ak.last.fm/serve/64/73929612.png</image><image size="large">http://userserve-ak.last.fm/serve/126/73929612.png</image><image size="extralarge">http://userserve-ak.last.fm/serve/252/73929612.png</image>
         * </artist>
         * <loved>0</loved>*/
        public void ReadXml(XmlReader reader)
        {
            XDocument doc = XDocument.Load(reader);
            if (null != doc.Root)
            {
                XElement rootElement = doc.Root;
                XElement element = rootElement.Element("artist");
                if (null != element)
                {
                    Artist = new LfmShortArtistInfo();
                    List<XElement> elements = element.Elements().ToList();
                    if (elements.Count > 1)
                    {
                        XElement artEl = element.Element("name");
                        if (null != artEl)
                        {
                            Artist.Name = artEl.Value;
                        }
                        artEl = element.Element("mbid");
                        if (null != artEl)
                        {
                            if (!string.IsNullOrWhiteSpace(artEl.Value))
                            {
                                Artist.Mbid = Guid.Parse(artEl.Value);
                            }
                        }

                        Artist.Images.AddRange(ExtractImages(element.Elements("image")));
                        element = rootElement.Element("loved");
                        if (null != element)
                        {
                            Loved = int.Parse(element.Value) != 0;
                        }
                    }
                    else
                    {
                        Artist.Name = element.Value;
                        XAttribute attribute = element.Attribute("mbid");
                        if (null != attribute)
                        {
                            if (!string.IsNullOrWhiteSpace(attribute.Value))
                            {
                                Artist.Mbid = Guid.Parse(attribute.Value);
                            }
                        }
                    }
                }
                element = rootElement.Element("name");
                if (null != element)
                {
                    Name = element.Value;
                }
                element = rootElement.Element("streamable");
                if (null != element)
                {
                    Streamable = int.Parse(element.Value) != 0;
                }
                element = rootElement.Element("mbid");
                if (null != element)
                {
                    if (!string.IsNullOrWhiteSpace(element.Value))
                    {
                        Mbid = Guid.Parse(element.Value);
                    }
                }
                element = rootElement.Element("album");
                if (null != element)
                {
                    Album = new LfmShortAlbumInfo();
                    Album.Name = element.Value;
                    XAttribute attribute = element.Attribute("mbid");
                    if (null != attribute)
                    {
                        if (!string.IsNullOrWhiteSpace(attribute.Value))
                        {
                            Album.Mbid = Guid.Parse(attribute.Value);
                        }
                    }
                }
                element = rootElement.Element("url");
                if (null != element)
                {
                    Url = element.Value;
                }
                element = rootElement.Element("date");
                if (null != element)
                {
                    DateTime = new LfmDateTime();
                    DateTime.DateTime = element.Value;
                    XAttribute attribute = element.Attribute("uts");
                    if (null != attribute)
                    {
                        DateTime.UnixTime = long.Parse(attribute.Value);
                    }
                }

                Images.AddRange(ExtractImages(rootElement.Elements("image")));
            }
        }

        private List<LfmImage> ExtractImages(IEnumerable<XElement> elements)
        {
            List<LfmImage> results = new List<LfmImage>();
            foreach (XElement imageElem in elements)
            {
                LfmImage image = new LfmImage();
                image.Url = imageElem.Value;
                XAttribute attribute = imageElem.Attribute("size");
                if (null != attribute)
                {
                    ImageSize size;
                    if (Enum.TryParse<ImageSize>(attribute.Value, out size))
                    {
                        image.Size = size;
                    }
                }

                results.Add(image);
            }

            return results;
        }

        public void WriteXml(XmlWriter writer)
        {
            XDocument doc = new XDocument();
            doc.Save(writer);
        }

        #endregion

        #region Overrided

        public override string ToString()
        {
            return string.Format("{0} - {1} [{2}]",
                Artist ?? new LfmShortArtistInfo {Name = ""},
                Name ?? "",
                DateTime ?? new LfmDateTime {DateTime = ""});
        }

        #endregion
    }
}