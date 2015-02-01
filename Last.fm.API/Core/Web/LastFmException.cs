//-----------------------------------------------------------------------
// <copyright file="LastFmException.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.IO;
using System.Net;
using Last.fm.API.Core.Types;

namespace Last.fm.API.Core.Web
{
    /// <summary>
    /// LastFm Exception
    /// </summary>
    public class LastFmException : Exception
    {
        /// <summary>
        /// Server Error
        /// </summary>
        public ErrorMessage LastFmError { get; protected set; }

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

        internal LastFmException(string message, Exception innerException, ErrorMessage errorMessage)
            : this(message, innerException as WebException)
        {
            LastFmError = errorMessage;
        }

        internal LastFmException(string message, Exception exception)
            : base(message, null != exception ? exception.InnerException : null)
        {
        }

        private ErrorMessage GetBaseResponse(WebException innerException)
        {
            if (innerException != null)
            {
                HttpWebResponse rep = (HttpWebResponse)(innerException.Response);
                Stream stream = rep.GetResponseStream();

                return BaseResponse.Deserialize<ErrorMessage>(stream);
            }

            return null;
        }

        #region Internal Exception creators

        internal static Exception CreateException(string message, Exception innerException, ErrorMessage errorMessage)
        {
            if (null != errorMessage)
            {
                return new LastFmException(message, innerException, errorMessage);
            }

            return new Exception(Constants.ReceivedBadRequestMsg, innerException);
        }

        internal static Exception CreateException(string message, ErrorMessage errorMessage)
        {
            if (null != errorMessage)
            {
                message = message.Trim();
                return
                    new LastFmException(string.IsNullOrWhiteSpace(message)
                        ? Constants.ReceivedBadRequestMsg
                        : message,
                        null, errorMessage);
            }

            return new Exception(Constants.ReceivedBadRequestMsg);
        }

        internal static Exception CreateException(ErrorMessage errorMessage)
        {
            return CreateException(Constants.ReceivedBadRequestMsg, errorMessage);
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
                return (WebException)exception;
            }

            return FindWebException(exception.InnerException);
        }

        #endregion

        #region Overrided

        public override string ToString()
        {
            if (null == LastFmError)
            {
                return base.ToString();
            }

            return string.Format("Code [{0}] : - {1}",
                LastFmError.Code,
                LastFmError.Message);
        }

        #endregion
    }
}
