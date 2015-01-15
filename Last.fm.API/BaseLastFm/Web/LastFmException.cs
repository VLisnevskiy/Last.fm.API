using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace Last.fm.API.BaseLastFm.Web
{
    /// <summary>
    /// LastFm Exception
    /// </summary>
    public sealed class LastFmException : Exception
    {
        /// <summary>
        /// Server Error
        /// </summary>
        public ServiceError LastFmError { get; private set; }

        /// <summary>
        /// Create new instance of LastFmException
        /// </summary>
        /// <param name="innerException">Inner Exception</param>
        public LastFmException(Exception innerException)
            : this("You received bad request", innerException)
        {
        }

        /// <summary>
        /// Create new instance of LastFmException
        /// </summary>
        /// <param name="message">Message of Exception</param>
        /// <param name="innerException">Inner Exception</param>
        public LastFmException(string message, Exception innerException)
            : base(message, innerException)
        {
            LastFmError = GetBaseResponse(innerException);
            HelpLink = "http://www.last.fm/api/errorcodes";
        }

        private ServiceError GetBaseResponse(Exception innerException)
        {
            WebException webException = (WebException)innerException.InnerException;
            if (webException != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ServiceError));
                HttpWebResponse rep = (HttpWebResponse)(webException.Response);
                Stream stream = rep.GetResponseStream();

                stream = BaseResponse.ExtractLfmStatusToStream(stream);

                if (stream != null)
                {
                    stream.Position = 0;
                    return (ServiceError)serializer.Deserialize(stream);
                }
            }

            return null;
        }

    }
}
