using System;
using System.Xml.Serialization;

namespace Last.fm.API.AuthServices
{
    /// <summary>
    /// AuthToken
    /// </summary>
    [XmlRoot("token")]
    public class AuthToken
    {
        /// <summary>
        /// Token
        /// </summary>
        [XmlText]
        public string Token { get; set; }

        private const string UrlFormater = "http://www.last.fm/api/auth/?api_key={0}&token={1}";

        [NonSerialized]
        private string url;

        /// <summary>
        /// Url to activate access
        /// </summary>
        public string Url
        {
            get { return url; }
        }

        private string SetUrlValue(string apiKey)
        {
            return url = string.Format(UrlFormater, apiKey, Token);
        }

        internal AuthToken SetUrl(string apiKey)
        {
            SetUrlValue(apiKey);
            return this;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return Token;
        }
    }
}