//-----------------------------------------------------------------------
// <copyright file="AuthSession.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;
using Last.fm.API.Core;

namespace Last.fm.API.Auth
{
    /// <summary>
    /// AuthSession
    /// </summary>
    [XmlRoot("session")]
    public class AuthSession : BaseResponse
    {
        /// <summary>
        /// Name
        /// </summary>
        [XmlElement("name")]
        public string UserName { get; set; }

        /// <summary>
        /// SessionKey
        /// </summary>
        [XmlElement("key")]
        public string SessionKey { get; set; }

        /// <summary>
        /// Subscriber
        /// </summary>
        [XmlElement("subscriber")]
        public bool Subscriber { get; set; }

        #region Overrided

        public override string ToString()
        {
            return string.Format("User [{0}] - sesssion key [{1}]",
                UserName,
                SessionKey);
        }

        #endregion
    }
}