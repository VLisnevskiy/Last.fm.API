//-----------------------------------------------------------------------
// <copyright file="Message.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.IO;
using System.Net;

namespace Last.fm.API.Core.Web
{
    /// <summary>
    /// Last.fm message.
    /// </summary>
    public abstract class Message : IDisposable
    {
        /// <summary>
        /// Request.
        /// </summary>
        public WebRequest Request { get; set; }

        /// <summary>
        /// Response.
        /// </summary>
        public WebResponse Response { get; set; }

        /// <summary>
        /// Web method.
        /// </summary>
        public WebMethod Method { get; protected set; }

        /// <summary>
        /// Exception
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Response stream.
        /// </summary>
        public Stream ResponseStream { get; protected set; }

        /// <summary>
        /// Create new message.
        /// </summary>
        /// <param name="method">Last.fm web method.</param>
        /// <returns>Return message.</returns>
        public static Message Create(WebMethod method)
        {
            return new LfmMessage(method);
        }

        /// <summary>
        /// Create new message.
        /// </summary>
        /// <param name="method">Last.fm web method.</param>
        /// <param name="parameters">Parameters value.</param>
        /// <returns>Return message.</returns>
        public static Message Create(WebMethod method, object[] parameters)
        {
            if (null == parameters)
            {
                throw new ArgumentNullException("parameters", "Parameter can't be null");
            }

            Message message = Create(method);
            message.Method.SetParamsValue(parameters);

            return message;
        }

        /// <summary>
        /// Set response stream
        /// </summary>
        /// <param name="stream">Response stream</param>
        public void SetResponseStream(Stream stream)
        {
            if (null != stream)
            {
                stream.Position = 0;
                ResponseStream = stream;
            }
        }

        private class LfmMessage : Message
        {
            public LfmMessage(WebMethod method)
            {
                Method = method;
            }
        }

        #region IDisposable

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method. 
            // Therefore, you should call GC.SupressFinalize to 
            // take this object off the finalization queue 
            // and prevent finalization code for this object 
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called. 
            if (!disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources. 
                if (disposing)
                {
                    //TODO: Dispose managed resources.
                    Request = null;
                    Response = null;
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here. 
                // If disposing is false, 
                // only the following code is executed.

                //TODO: Dispose unmanaged resources.

                // Note disposing has been done.
                disposed = true;
            }
        }

        ~Message()
        {
            Dispose(false);
        }

        #endregion

        #region Overrided

        public override string ToString()
        {
            if (null != ResponseStream)
            {
                ResponseStream.Position = 0;
                StreamReader reader = new StreamReader(ResponseStream);
                string message = reader.ReadToEnd();
                ResponseStream.Position = 0;

                return message;
            }

            if (null != Method)
            {
                return Method.GetRequestBody();
            }

            return "...";
        }

        #endregion
    }
}