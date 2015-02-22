//-----------------------------------------------------------------------
// <copyright file="UserInfo.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Serialization;
using Last.fm.API.Core;
using Last.fm.API.Core.Types;

namespace Last.fm.API.User
{
    /// <summary>
    /// Last.fm User information.
    /// </summary>
    [XmlRoot("user")]
    public class UserInfo : BaseResponse
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("realname")]
        public string RealName { get; set; }

        [XmlElement("url")]
        public string ProfileUrl { get; set; }

        [XmlElement("image")]
        public List<LfmImage> Images { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }

        [XmlElement("age")]
        public int Age { get; set; }

        [XmlElement("geder")]
        public LfmGender Gender { get; set; }

        [XmlElement("subscriber")]
        public bool Subscriber { get; set; }

        [XmlElement("playcount")]
        public int PlayCount { get; set; }

        [XmlElement("playlists")]
        public int Playlists { get; set; }

        [XmlElement("bootstrap")]
        public int Bootstrap { get; set; }

        [XmlElement("registered")]
        public LfmDateTime Registered { get; set; }

        [XmlElement("type")]
        public string Type { get; set; }

        [XmlElement("scrobblesource")]
        public ScrobbleSource ScrobbleSource { get; set; }

        [XmlElement("recenttrack")]
        public RecentTrack RecentTrack { get; set; }

        #region Overrided

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
