using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Last.fm.API.BaseLastFm;

namespace Last.fm.API.TrackServices
{
    /// <summary>
    /// 
    /// </summary>
    internal class TrackServices : BaseLastFmClient<ITrackServicesApi>, ITrackServices
    {
        public TrackServices(string apiKey, string apiSig)
            : base(apiKey, apiSig)
        {
        }
    }
}
