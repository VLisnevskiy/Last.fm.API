//-----------------------------------------------------------------------
// <copyright file="LastFmSettings.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Threading;

namespace Last.fm.API.Core.Settings
{
    /// <summary>
    /// LastFm API configuration settings
    /// </summary>
    public sealed class LastFmSettings
    {
        #region Singleton implementation

        private static Lazy<LastFmSettings> instance;

        /// <summary>
        /// Instance of LastFm API Settings
        /// </summary>
        public static LastFmSettings Instance
        {
            get
            {
                if (null == instance)
                {
                    LoadSettings();
                }

                return instance.Value;
            }
        }

        private static LastFmSettings CreateInstance()
        {
            return new LastFmSettings();
        }

        /// <summary>
        /// Load Settings for LastFm API
        /// </summary>
        public static void LoadSettings()
        {
            instance = new Lazy<LastFmSettings>(CreateInstance, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        private LastFmSettings()
        {
            ThreadId = Thread.CurrentThread.ManagedThreadId;
            LoadConfigurationSettings();
        }

        #endregion

        private void LoadConfigurationSettings()
        {
            ApiKey = "4930efce82e84fef13f6309659fe2bcd";
            ApiSig = "b78261d1e86a65fe8f78abbd322681ac";

            CloseTimeout = new TimeSpan(0, 1, 0);
            OpenTimeout = new TimeSpan(0, 1, 0);
            ReceiveTimeout = new TimeSpan(0, 10, 0);
            SendTimeout = new TimeSpan(0, 1, 0);
        }

        internal int ThreadId { get; private set; }

        /// <summary>
        /// Url on LastFm API
        /// </summary>
        public const string LastFmApiUrl = "https://ws.audioscrobbler.com/2.0/";

        /// <summary>
        /// WebServices ApiKey
        /// </summary>
        public string ApiKey { get; private set; }

        /// <summary>
        /// WebServices ApiSig
        /// </summary>
        public string ApiSig { get; private set; }

        /// <summary>
        /// Timeout in minutes before Close
        /// </summary>
        public TimeSpan CloseTimeout { get; set; }

        /// <summary>
        /// Timeout in minutes before Open
        /// </summary>
        public TimeSpan OpenTimeout { get; set; }

        /// <summary>
        /// Timeout in minutes before Receive
        /// </summary>
        public TimeSpan ReceiveTimeout { get; set; }

        /// <summary>
        /// Timeout in minutes before Send
        /// </summary>
        public TimeSpan SendTimeout { get; set; }

        #region Overriden methods

        public override string ToString()
        {
            string text = string.Format("Url = [{0}] - ApiKey = [{1}] - ApiSig = [{2}]",
                LastFmApiUrl,
                ApiKey,
                ApiSig);

            return text;
        }

        #endregion
    }
}
