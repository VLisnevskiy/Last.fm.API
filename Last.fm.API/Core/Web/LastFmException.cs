//-----------------------------------------------------------------------
// <copyright file="LastFmException.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.IO;
using System.Net;
using Last.fm.API.BaseLastFm.Web;

namespace Last.fm.API.Core.Web
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
        public LastFmException(WebException innerException)
            : this(Constants.ReceivedBadRequestMsg, innerException)
        {
        }

        /// <summary>
        /// Create new instance of LastFmException
        /// </summary>
        /// <param name="message">Message of Exception</param>
        /// <param name="innerException">Inner Exception</param>
        public LastFmException(string message, WebException innerException)
            : base(message, innerException)
        {
            LastFmError = GetBaseResponse(innerException);
            HelpLink = "http://www.last.fm/api/errorcodes";
        }

        internal LastFmException(string message, Exception innerException, ServiceError error)
            : this(message, innerException as WebException)
        {
            LastFmError = error;
        }

        private ServiceError GetBaseResponse(WebException innerException)
        {
            if (innerException != null)
            {
                HttpWebResponse rep = (HttpWebResponse)(innerException.Response);
                Stream stream = rep.GetResponseStream();

                return BaseResponse.Deserialize<ServiceError>(stream);
            }

            return null;
        }

        #region Internal Exception creators

        internal static Exception CreateException(string message, Exception innerException, ServiceError error)
        {
            if (null != error)
            {
                return new LastFmException(message, innerException, error);
            }

            return new Exception(Constants.ReceivedBadRequestMsg, innerException);
        }

        internal static Exception CreateException(string message, ServiceError error)
        {
            if (null != error)
            {
                message = message.Trim();
                return
                    new LastFmException(string.IsNullOrWhiteSpace(message)
                        ? Constants.ReceivedBadRequestMsg
                        : message,
                        null, error);
            }

            return new Exception(Constants.ReceivedBadRequestMsg);
        }

        internal static Exception CreateException(ServiceError error)
        {
            return CreateException(Constants.ReceivedBadRequestMsg, error);
        }

        internal static Exception CreateWebException(Exception innerException)
        {
            WebException webException = FindWebException(innerException);
            if (null == webException)
            {
                return innerException;
            }

            return new LastFmException(webException);
        }

        internal static Exception CreateWebException(string message, Exception innerException)
        {
            WebException webException = FindWebException(innerException);
            if (null == webException)
            {
                return innerException;
            }

            return new LastFmException(message, webException);
        }

        private static WebException FindWebException(Exception exception)
        {
            if (null == exception)
            {
                return null;
            }

            if (exception is WebException)
            {
                return (WebException) exception;
            }

            return FindWebException(exception.InnerException);
        }

        #endregion
    }
}
