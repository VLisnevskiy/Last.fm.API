//-----------------------------------------------------------------------
// <copyright file="LastFmWebHttpBinding.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ServiceModel;
using Last.fm.API.Core.Settings;

namespace Last.fm.API.Core.Web
{
    internal class LastFmWebHttpBinding : WebHttpBinding
    {
        public LastFmWebHttpBinding()
            : base(WebHttpSecurityMode.Transport)
        {
            SetTimeOut();
            MaxReceivedMessageSize = LastFmSettings.Instance.MaxReceivedMessageSize;
            MaxBufferPoolSize = LastFmSettings.Instance.MaxReceivedMessageSize;
            MaxBufferSize = LastFmSettings.Instance.MaxReceivedMessageSize;
        }

        public new EnvelopeVersion EnvelopeVersion
        {
            get { return EnvelopeVersion.None; }
        }

        private void SetTimeOut()
        {
            CloseTimeout = LastFmSettings.Instance.CloseTimeout;
            OpenTimeout = LastFmSettings.Instance.OpenTimeout;
            ReceiveTimeout = LastFmSettings.Instance.ReceiveTimeout;
            SendTimeout = LastFmSettings.Instance.SendTimeout;
        }
    }
}