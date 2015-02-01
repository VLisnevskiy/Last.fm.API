//-----------------------------------------------------------------------
// <copyright file="AuthToken.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
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

        /// <summary>
        /// Implicit cast to AuthToken from string
        /// </summary>
        /// <param name="input">Input string value</param>
        /// <returns>Output AuthToken object</returns>
        public static implicit operator AuthToken(string input)
        {
            return checked
                (new AuthToken
                {
                    Token = (new Guid(input))
                    .ToString("N")
                    .ToLowerInvariant()
                });
        }

        /// <summary>
        /// Implicit cast to string from AuthToken
        /// </summary>
        /// <param name="input">Input AuthToken object value</param>
        /// <returns>Output string object</returns>
        public static implicit operator string(AuthToken input)
        {
            if (null == input)
            {
                return string.Empty;
            }
            else
            {
                return input.Token;
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