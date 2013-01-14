using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace Last.fm.API.BaseLastFm
{
    internal class LastFmChannelFactory<TChannel> : ChannelFactory<TChannel>
    {
        #region Private

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
        }

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

    internal class LastFmHttpBehavior : WebHttpBehavior
    {
        protected override System.ServiceModel.Dispatcher.QueryStringConverter GetQueryStringConverter(OperationDescription operationDescription)
        {
            return new CustomQueryStringConverter();
        }
    }

    internal class CustomQueryStringConverter : System.ServiceModel.Dispatcher.QueryStringConverter
    {
        public override bool CanConvert(Type type)
        {
            if (type == typeof(string[]))
            {
                return true;
            }

            if (type == typeof(double?))
            {
                return true;
            }

            if (type == typeof(int?))
            {
                return true;
            }

            if (type == typeof(byte?))
            {
                return true;
            }

            return base.CanConvert(type);
        }

        public override object ConvertStringToValue(string parameter, Type parameterType)
        {
            if (parameterType == typeof(string[]))
            {
                string[] parms = parameter.Split(',');
                return parms;
            }

            if (parameterType == typeof(double?))
            {
                return parameter;
            }

            if (parameterType == typeof(int?))
            {
                return parameter;
            }

            if (parameterType == typeof(byte?))
            {
                return parameter;
            }

            return base.ConvertStringToValue(parameter, parameterType);
        }

        public override string ConvertValueToString(object parameter, Type parameterType)
        {
            if (parameterType == typeof(string[]))
            {
                string valstring = string.Join(",", (string[])parameter);
                return valstring;
            }

            if (parameterType == typeof(double?))
            {
                double? val = (double?)parameter;
                return val == null ? string.Empty:val.ToString();
            }

            if (parameterType == typeof (int?))
            {
                int? val = (int?) parameter;
                return val == null ? string.Empty : val.ToString();
            }

            if (parameterType == typeof(byte?))
            {
                byte? val = (byte?)parameter;
                return val == null ? string.Empty : val.ToString();
            }

            return base.ConvertValueToString(parameter, parameterType);
        }
    }
}
