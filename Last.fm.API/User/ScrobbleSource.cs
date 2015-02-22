//-----------------------------------------------------------------------
// <copyright file="ScrobbleSource.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace Last.fm.API.User
{
    [XmlRoot("scrobblesource")]
    public class ScrobbleSource
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }
    }
}