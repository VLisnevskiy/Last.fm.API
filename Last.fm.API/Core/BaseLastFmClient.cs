//-----------------------------------------------------------------------
// <copyright file="BaseLastFmClient.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Last.fm.API.Core.Settings;
using Last.fm.API.Core.Web;

namespace Last.fm.API.Core
{
    /// <summary>
    /// Base client to call Last.fm services
    /// </summary>
    /// <typeparam name="TChannel">Type of using channel</typeparam>
    public abstract class BaseLastFmClient<TChannel> : IDisposable, IApiKeys
    {
        /// <summary>
        /// Channel
        /// </summary>
        public TChannel Channel { get; protected set; }

        /// <summary>
        /// Constructor of BaseLastFmClient.
        /// </summary>
        protected BaseLastFmClient()
        {
            Channel = CreateChannel();
        }

        /// <summary>
        /// Creates a channel of a specified type to a specified endpoint address.
        /// </summary>
        /// <returns>
        /// The <paramref><name>TChannel</name></paramref> of type <see cref="T:Last.fm.API.Core.Web.LastFmProxy"/> created by the proxy factory.
        /// </returns>
        public TChannel CreateChannel()
        {
            return new LastFmProxy<TChannel>().GetTransparentProxy();
        }

        #region Auth help method

        protected string BuildSignature(string formater, params string[] args)
        {
            List<object> @params = new List<object>();
            @params.Add(ApiKey);
            @params.AddRange(args);
            @params.Add(ApiSig);

            return string.Format(formater, @params.ToArray()).MD5();
        }

        #endregion

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
                    Channel = default(TChannel);
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

        ~BaseLastFmClient()
        {
            Dispose(false);
        }

        #endregion

        #region IApiKeys

        public string ApiKey
        {
            get { return LastFmSettings.Instance.ApiKey; }
        }

        public string ApiSig
        {
            get { return LastFmSettings.Instance.ApiSig; }
        }

        #endregion
    }
}
