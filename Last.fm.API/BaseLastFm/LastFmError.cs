using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Last.fm.API.BaseLastFm
{
    /// <summary>
    /// 
    /// </summary>
    public class LastFmError : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public ServicesError Error { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="innerException"></param>
        public LastFmError(Exception innerException)
            : this("You received bad request", innerException)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public LastFmError(string message, Exception innerException)
            : base(message, innerException)
        {
            Error = GetBaseResponse(innerException);
            HelpLink = "http://www.last.fm/api/errorcodes";
        }

        /// <summary>
        /// 
        /// </summary>
        //public new string HelpLink { get; private set; }

        protected ServicesError GetBaseResponse(Exception innerException)
        {
            WebException webException = (WebException)innerException.InnerException;
            if (webException != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ServicesError));
                HttpWebResponse rep = (HttpWebResponse)(webException.Response);
                Stream stream = rep.GetResponseStream();
                if (stream != null)
                {
                    stream.Position = 0;
                    return (ServicesError)serializer.Deserialize(stream);
                }
            }

            return null;
        }

    }
}
