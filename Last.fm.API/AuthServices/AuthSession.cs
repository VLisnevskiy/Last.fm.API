using System.Xml.Serialization;

namespace Last.fm.API.AuthServices
{
    /// <summary>
    /// AuthSession
    /// </summary>
    [XmlRoot("session")]
    public class AuthSession
    {
        /// <summary>
        /// Name
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        [XmlElement("key")]
        public string Key { get; set; }

        /// <summary>
        /// Subscriber
        /// </summary>
        [XmlElement("subscriber")]
        public bool Subscriber { get; set; }
    }
}