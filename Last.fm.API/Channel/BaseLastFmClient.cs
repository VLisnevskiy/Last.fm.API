using System;
using System.ServiceModel.Channels;

namespace Last.fm.API.Channel
{
    internal abstract class BaseLastFmClient<TChannel> : IDisposable, IApiKey
    {
        protected TChannel Channel { get; set; }

        protected BaseLastFmClient(string apiKey)
        {
            ApiKey = apiKey;
            Channel = LastFmServicesHolder.CreateChannel<TChannel>();
        }

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

        public string ApiKey { get; set; }
    }
}
