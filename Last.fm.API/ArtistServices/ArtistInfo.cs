using System;
using System.Xml.Serialization;
using Last.fm.API.BaseLastFm;

namespace Last.fm.API.ArtistServices
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [XmlRoot("artist")]
    public class ArtistInfo : BaseResponse
    {
        /// <summary>
        /// Artist Name
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

    }
}