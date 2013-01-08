using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace Last.fm.API.BaseLastFm
{
    class LastFmError : Exception
    {
        private readonly ServicesError error;
        public ServicesError Error { get { return error; } }

        public LastFmError(Exception innerException)
            : base("You received bad request", innerException)
        {
            error = GetBaseResponse(innerException);
        }

        public LastFmError(string message, Exception innerException)
            : base(message, innerException)
        {
            error = GetBaseResponse(innerException);
        }

        protected ServicesError GetBaseResponse(Exception innerException)
        {
            ServicesError response = null;
            WebException webException = innerException.InnerException as WebException;
            if (webException != null)
            {
                HttpWebResponse rep = (HttpWebResponse)(webException.Response);
                Stream stream = rep.GetResponseStream();
                XmlSerializer serializer = new XmlSerializer(typeof(ServicesError));
                response = stream != null ? (ServicesError)serializer.Deserialize(stream) : null;
            }

            return response;
        }

    }
}
