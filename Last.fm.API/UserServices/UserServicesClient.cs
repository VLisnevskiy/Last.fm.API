using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Last.fm.API.Channel;

namespace Last.fm.API.UserServices
{
    internal class UserServicesClient : BaseLastFmClient<IUserServicesApi>, IUserServices
    {
        public UserServicesClient(string apiKey)
            : base(apiKey)
        {
        }

        #region IUserServices methods

        public XmlElement GetRecentTracks(string user)
        {
            XmlElement res;
            try
            {
                res = Channel.GetRecentTracks(ApiKey, user);
            }
            catch (ProtocolException e)
            {
                HttpWebResponse rep = (HttpWebResponse)(((WebException)e.InnerException).Response);
                Stream stream = rep.GetResponseStream();

                var xml = XDocument.Load(rep.GetResponseStream());

                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return res;
        }

        #endregion

        ~UserServicesClient()
        {
            Dispose(false);
        }
    }
}
