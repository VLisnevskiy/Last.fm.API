using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Last.fm.API.BaseLastFm
{
    internal class LastFmChannelFactory<TChannel> : ChannelFactory<TChannel>
    {
        #region Private
        /*
        private LastFmChannelFactory()
        {
            InitializeEndpoint();
        }

        private LastFmChannelFactory(Binding binding, EndpointAddress address)
            : base(binding, address)
        {
            InitializeEndpoint();
        }

        private LastFmChannelFactory(Binding binding, string address)
            : base(binding, address)
        {
            InitializeEndpoint();
        }

        private LastFmChannelFactory(ServiceEndpoint endpoint)
            : base(endpoint)
        {
            InitializeEndpoint();
        }

        private LastFmChannelFactory(string endpointConfigurationName)
            : base(endpointConfigurationName)
        {
            InitializeEndpoint();
        }

        private LastFmChannelFactory(string endpointConfigurationName, EndpointAddress endpoint)
            : base(endpointConfigurationName, endpoint)
        {
            InitializeEndpoint();
        }

        private LastFmChannelFactory(Type channelType)
            : base(channelType)
        {
            InitializeEndpoint();
        }*/

        private void InitializeEndpoint()
        {
            Endpoint.Address = new EndpointAddress("http://ws.audioscrobbler.com/2.0/");
            Endpoint.Behaviors.Add(new LastFmHttpBehavior());
        }

        #endregion

        public LastFmChannelFactory(Binding binding)
            : base(binding)
        {
            InitializeEndpoint();
        }

        public new TChannel CreateChannel()
        {
            TChannel channel = base.CreateChannel();
            ((IClientChannel)channel).Open();
            return channel;
        }
    }
}
