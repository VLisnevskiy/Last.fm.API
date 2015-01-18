//-----------------------------------------------------------------------
// <copyright file="AuthToken.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Serialization;
using Last.fm.API.Core;
using Last.fm.API.Core.Settings;

namespace Last.fm.API.Auth
{
    /// <summary>
    /// AuthToken
    /// </summary>
    [XmlRoot("token")]
    public class AuthToken : BaseResponse
    {
        /// <summary>
        /// Token
        /// </summary>
        [XmlText]
        public string Token { get; set; }

        /// <summary>
        /// Url to activate access
        /// </summary>
        public string Url
        {
            get
            {
                return string.Format(Constants.SecurityUrl,
                    LastFmSettings.Instance.ApiKey,
                    Token);
            }
        }

        #region Overrided

        public override string ToString()
        {
            return string.Format("{0}",
                Token);
        }

        #endregion
    }
}