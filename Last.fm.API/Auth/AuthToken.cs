//-----------------------------------------------------------------------
// <copyright file="AuthToken.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Serialization;
using Last.fm.API.BaseLastFm;
using Last.fm.API.Core;

namespace Last.fm.API.Auth
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
            return url = string.Format(Constants.SecurityUrl, apiKey, Token);
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