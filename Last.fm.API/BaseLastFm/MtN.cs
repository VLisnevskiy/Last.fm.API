namespace Last.fm.API.BaseLastFm
{
    /// <summary>
    /// Names of service methods
    /// </summary>
    internal abstract class MtN
    {
        /// <summary>
        /// Auth category
        /// </summary>
        public class Auth
        {
            /// <summary>
            /// "auth.getMobileSession"
            /// </summary>
            public const string MobileSession = "auth.getMobileSession";

            /// <summary>
            /// "auth.getToken"
            /// </summary>
            public const string Token = "auth.getToken";

            /// <summary>
            /// "auth.getSession"
            /// </summary>
            public const string Session = "auth.getSession";
        }

        /// <summary>
        /// User category
        /// </summary>
        public class User
        {
            /// <summary>
            /// "user.getArtistTracks"
            /// </summary>
            public const string ArtistTracks = "user.getArtistTracks";

            /// <summary>
            /// "user.getBannedTracks"
            /// </summary>
            public const string BannedTracks = "user.getBannedTracks";

            /// <summary>
            /// "user.getRecentTracks"
            /// </summary>
            public const string RecentTracks = "user.getRecentTracks";

            /// <summary>
            /// "user.getInfo"
            /// </summary>
            public const string Info = "user.getInfo";
        }
    }
}