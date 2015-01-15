using System;
using System.Net;
using System.Security.Cryptography;
using System.ServiceModel.Channels;
using System.Text;
using Last.fm.API.BaseLastFm.Web;

namespace Last.fm.API.BaseLastFm
{
    /// <summary>
    /// Base client to call Last.fm services
    /// </summary>
    /// <typeparam name="TChannel">Type of using channel</typeparam>
    public abstract class BaseLastFmClient<TChannel> : IDisposable, IApiKeys
    {
        /// <summary>
        /// Using Channel
        /// </summary>
        public TChannel Channel { get; protected set; }

        protected BaseLastFmClient(string apiKey)
        {
            this.apiKey = apiKey;
            Channel = CreateChannel<TChannel>();
            disposed = false;
        }

        protected BaseLastFmClient(string apiKey, string apiSig)
            : this(apiKey)
        {
            this.apiSig = apiSig;
        }
        
        
        /// <summary>
        /// Creates a channel of a specified type to a specified endpoint address.
        /// </summary>
        /// <typeparam name="T">Type of using channel</typeparam>
        /// <returns>
        /// The <paramref><name>T</name></paramref> of type <see cref="T:System.ServiceModel.Channels.IChannel"/> created by the factory.
        /// </returns>
        public static T CreateChannel<T>()
        {
            return new LastFmChannelFactory<T>().CreateChannel();
        }

        /// <summary>
        /// Base method to call services
        /// </summary>
        /// <typeparam name="T">Type of needed response</typeparam>
        /// <param name="servicesMethod">Services method</param>
        /// <returns>Response from services</returns>
        protected T Invoke<T>(Func<T> servicesMethod)
        {
            T response;
            try
            {
                response = servicesMethod();
            }
            catch (Exception e)
            {
                if (e.InnerException is WebException)
                {
                    throw new LastFmException(e);
                }

                throw new Exception("Some Exception happened during calling WebMethod", e);
            }

            return response;
        }

        protected string GetAuthToken(string password, string username)
        {
            return CreateSignature(username + CreateSignature(password));
        }

        protected string BuildSig(string formater, params object[] args)
        {
            object[] param = new object[args.Length + 2];
            param[0] = ApiKey;
            for (int i = 0; i < args.Length; i++)
            {
                param[i + 1] = args[i];
            }

            param[param.Length - 1] = ApiSig;
            return CreateSignature(string.Format(formater, param));
        }

        protected string CreateSignature(string parameters)
        {
            string res = string.Empty;
            byte[] hash = new MD5CryptoServiceProvider()
                .ComputeHash(Encoding.UTF8.GetBytes(parameters));
            foreach (byte b in hash)
            {
                res += b.ToString("x2");
            }

            return res;
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
            if (!disposed)
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

        #region IApiKeys

        private readonly string apiKey;

        public string ApiKey { get { return apiKey; } }

        private readonly string apiSig;

        public string ApiSig { get { return apiSig; } }

        #endregion
    }
}
