using System.ServiceModel;

namespace Last.fm.API.BaseLastFm.Web
{
    /// <summary>
    /// A factory that creates channels of different types that are used by clients to send messages to variously configured service endpoints.
    /// </summary>
    /// <typeparam name="TChannel">The type of channel produced by the channel factory. This type must be either <see cref="T:System.ServiceModel.Channels.IOutputChannel"/> or <see cref="T:System.ServiceModel.Channels.IRequestChannel"/>.</typeparam>
    public class LastFmChannelFactory<TChannel> : ChannelFactory<TChannel>
    {
        private void InitializeEndpoint()
        {
            Endpoint.Address = new EndpointAddress("http://ws.audioscrobbler.com/2.0/");
            Endpoint.Behaviors.Add(new LastFmWebHttpBehavior());
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ServiceModel.ChannelFactory`1"/> class.
        /// </summary>
        public LastFmChannelFactory()
            : base(new WebHttpBinding())
        {
            InitializeEndpoint();
        }
        
        /// <summary>
        /// Creates a channel of a specified type to a specified endpoint address.
        /// </summary>
        /// <returns>
        /// The <paramref><name>TChannel</name></paramref> of type <see cref="T:System.ServiceModel.Channels.IChannel"/> created by the factory.
        /// </returns>
        public new TChannel CreateChannel()
        {
            TChannel channel = base.CreateChannel();
            ((IClientChannel)channel).Open();
            return channel;
        }
    }
}
