using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Last.fm.API.BaseLastFm;

namespace Last.fm.API.UserServices
{
    internal class UserServicesClient : BaseLastFmClient<IUserServicesApi>, IUserServices
    {
        public UserServicesClient(string apiKey)
            : base(apiKey)
        {
        }

        #region IUserServices methods

        public XmlDocument GetRecentTracks(string user)
        {
            XmlDocument res = BaseInvoke(() => Channel.GetRecentTracks(ApiKey, user));
            return res;
        }

        #endregion

        #region IDisposable

        ~UserServicesClient()
        {
            Dispose(false);
        }

        #endregion

    }
}
