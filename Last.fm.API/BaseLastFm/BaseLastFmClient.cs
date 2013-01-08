using System;
using System.ServiceModel.Channels;

namespace Last.fm.API.BaseLastFm
{
    /// <summary>
    /// Base client to call Last.fm services
    /// </summary>
    /// <typeparam name="TChannel">Type of using channel</typeparam>
    internal abstract class BaseLastFmClient<TChannel> : IDisposable, IApiKey
    {
        /// <summary>
        /// Using Channel
        /// </summary>
        protected TChannel Channel { get; set; }

        protected BaseLastFmClient(string apiKey)
        {
            ApiKey = apiKey;
            Channel = LastFmServicesHolder.CreateChannel<TChannel>();
            disposed = false;
        }

        /// <summary>
        /// Base method to call services
        /// </summary>
        /// <typeparam name="T">Type of needed response</typeparam>
        /// <param name="servicesMethod">Services method</param>
        /// <returns>Response from services</returns>
        protected T BaseInvoke<T>(Func<T> servicesMethod)
        {
            T response;
            try
            {
                response = servicesMethod();
            }
            catch (Exception e)
            {
                throw new LastFmError(e);
            }

            return response;
        }

        #region IDisposable

        private bool disposed;

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
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources. 
                if (disposing)
                {
                    //TODO: Dispose managed resources.
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here. 
                // If disposing is false, 
                // only the following code is executed.

                //TODO: Dispose unmanaged resources.
                ((IChannel)Channel).Close();

                // Note disposing has been done.
                disposed = true;
            }
        }

        ~BaseLastFmClient()
        {
            Dispose(false);
        }

        #endregion

        #region IApiKey

        public string ApiKey { get; set; }

        #endregion
    }
}
