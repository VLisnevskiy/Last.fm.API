//-----------------------------------------------------------------------
// <copyright file="Constants.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Last.fm.API.Core
{
    /// <summary>
    /// All Constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Header text of Xml document
        /// </summary>
        public const string XmlDocumentHeader = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";

        /// <summary>
        /// 
        /// </summary>
        public const string StatusAttribute = "status";

        /// <summary>
        /// Root lfm element of xml response
        /// </summary>
        public const string RootElementLfm = "lfm";

        /// <summary>
        /// Error element of xml response
        /// </summary>
        public const string ErrorElement = "error";

        /// <summary>
        /// Ok
        /// </summary>
        public const string Ok = "Ok";

        /// <summary>
        /// Url to get security
        /// </summary>
        public const string SecurityUrl = "http://www.last.fm/api/auth/?api_key={0}&token={1}";

        internal const int NotAuthorizedTokenCode = 14;

        internal const int InvalidMethodSignature = 13;

        internal const int ThisTokenHasExpired = 15;

        internal const int InvalidAuthenticationToken = 4;

        internal const string ReceivedBadRequestMsg = "You received bad request";
    }
}
