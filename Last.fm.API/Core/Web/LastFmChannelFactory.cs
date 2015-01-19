//-----------------------------------------------------------------------
// <copyright file="LastFmChannelFactory.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ServiceModel;
using Last.fm.API.Core.Settings;

namespace Last.fm.API.Core.Web
{
    /// <summary>
    /// A factory that creates channels of different types that are used by clients to send messages to variously configured service endpoints.
    /// </summary>
    /// <typeparam name="TChannel">The type of channel produced by the channel factory. This type must be either <see cref="T:System.ServiceModel.Channels.IOutputChannel"/> or <see cref="T:System.ServiceModel.Channels.IRequestChannel"/>.</typeparam>
    internal sealed class LastFmChannelFactory<TChannel> : ChannelFactory<TChannel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ServiceModel.ChannelFactory`1"/> class.
        /// </summary>
        public LastFmChannelFactory()
            : base(new LastFmWebHttpBinding())
        {
            Endpoint.Address = new EndpointAddress(LastFmSettings.LastFmApiUrl);
            Endpoint.Behaviors.Add(new LastFmWebHttpBehavior());
        }

        /// <summary>
        /// Creates a channel of a specified type to a specified endpoint address.
        /// </summary>
        /// <returns>
        /// The <paramref><name>TChannel</name></paramref> of type <see cref="T:System.ServiceModel.Channels.IChannel"/> created by the factory.
        /// </returns>
        public new TChannel CreateChannel()
        {
            RealProxy = new LastFmProxy<TChannel>(base.CreateChannel());
            TChannel channel = RealProxy.GetTransparentProxy();

            return channel;
        }

        public LastFmProxy<TChannel> RealProxy { get; private set; }
    }
}
