//-----------------------------------------------------------------------
// <copyright file="BaseLastFmClient.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Security.Cryptography;
using System.Text;
using Last.fm.API.Core.Settings;
using Last.fm.API.Core.Web;

namespace Last.fm.API.Core
{
    /// <summary>
    /// Base client to call Last.fm services
    /// </summary>
    /// <typeparam name="TChannel">Type of using channel</typeparam>
    internal abstract class BaseLastFmClient<TChannel> : IDisposable, IApiKeys
    {
        /// <summary>
        /// Using Channel
        /// </summary>
        public TChannel Channel { get; protected set; }

        protected BaseLastFmClient()
        {
            disposed = false;
            ApiKey = LastFmSettings.Instance.ApiKey;
            ApiSig = LastFmSettings.Instance.ApiSig;
            Channel = CreateChannel();
        }

        /// <summary>
        /// Creates a channel of a specified type to a specified endpoint address.
        /// </summary>
        /// <typeparam name="T">Type of using channel</typeparam>
        /// <returns>
        /// The <paramref><name>T</name></paramref> of type <see cref="T:System.ServiceModel.Channels.IChannel"/> created by the factory.
        /// </returns>
        public TChannel CreateChannel()
        {
            LastFmChannelFactory<TChannel> factory = new LastFmChannelFactory<TChannel>();
            ChannelFactory = factory;

            return factory.CreateChannel();
        }

        public LastFmChannelFactory<TChannel> ChannelFactory { get; private set; }

        public bool IsFaulted
        {
            get
            {
                if (null == ChannelFactory)
                {
                    return false;
                }

                if (null == ChannelFactory.RealProxy)
                {
                    return false;
                }

                return ChannelFactory.RealProxy.IsFaulted;
            }
        }

        #region Auth help methods

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

        #endregion

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

        public string ApiKey { get; private set; }

        public string ApiSig { get; private set; }

        #endregion
    }
}
