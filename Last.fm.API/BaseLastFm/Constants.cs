using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Last.fm.API.BaseLastFm
{
    /// <summary>
    /// Constants class, contains some constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// "?method="
        /// </summary>
        public const string METHOD = "?method=";

        /// <summary>
        /// "&amp;raw=true"
        /// </summary>
        public const string RAW_DATA = "&raw=true";

        /// <summary>
        /// "&amp;api_key={apiKey}"
        /// </summary>
        public const string API_KEY = "&api_key={apiKey}";

        /// <summary>
        /// "&amp;limit={limit}"
        /// </summary>
        public const string LIMIT = "&limit={limit}";

        /// <summary>
        /// "&amp;user={user}"
        /// </summary>
        public const string USER = "&user={user}";

        /// <summary>
        /// "&amp;artist={artist}"
        /// </summary>
        public const string ARTIST = "&artist={artist}";

        /// <summary>
        /// "&amp;
        /// </summary>
        public const string PAGE = "&page={page}";

        /// <summary>
        /// "&amp;
        /// </summary>
        public const string FROM = "&from={from}";

        /// <summary>
        /// "&amp;
        /// </summary>
        public const string EXTENDED = "&extended={extended}";

        /// <summary>
        /// "&amp;
        /// </summary>
        public const string TO = "&to={to}";

        /// <summary>
        /// "&amp;
        /// </summary>
        public const string START_TIMESTAMP = "&startTimestamp={startTimestamp}";

        /// <summary>
        /// "&amp;
        /// </summary>
        public const string END_TIMESTAMP = "&endTimestamp={endTimestamp}";

        /// <summary>
        /// "&amp;
        /// </summary>
        public const string FESTIVALS_ONLY = "&festivalsonly={festivalsonly}";
    }
}
