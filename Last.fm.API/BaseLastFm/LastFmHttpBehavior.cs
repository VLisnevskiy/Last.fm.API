using System;
using System.IO;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Last.fm.API.BaseLastFm
{
    internal class LastFmHttpBehavior : WebHttpBehavior
    {
        protected override QueryStringConverter GetQueryStringConverter(OperationDescription operationDescription)
        {
            return new LastFmQueryStringConverter();
        }

        protected override IClientMessageFormatter GetRequestClientFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
        {
            IClientMessageFormatter formatter = base.GetRequestClientFormatter(operationDescription, endpoint);
            return new LastFmClientMessageFormatter(formatter, operationDescription, endpoint);
        }

        protected override IClientMessageFormatter GetReplyClientFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
        {
            IClientMessageFormatter formatter = base.GetReplyClientFormatter(operationDescription, endpoint);
            return new LastFmClientMessageFormatter(formatter, operationDescription, endpoint);
        }
    }

    internal class LastFmClientMessageFormatter : IClientMessageFormatter
    {
        private readonly IClientMessageFormatter innerFormater;

        private OperationDescription operation;
        private ServiceEndpoint endpoint;

        public LastFmClientMessageFormatter(IClientMessageFormatter original)
        {
            innerFormater = original;
        }

        public LastFmClientMessageFormatter(IClientMessageFormatter original,
            OperationDescription operation, ServiceEndpoint endpoint)
            : this(original)
        {
            this.endpoint = endpoint;
            this.operation = operation;
        }

        public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
        {
            Message message = innerFormater.SerializeRequest(messageVersion, parameters);
            return message;
        }

        public object DeserializeReply(Message message, object[] parameters)
        {
            object r = innerFormater.DeserializeReply(message, parameters);
            string t = message.ToString();
            throw new System.NotImplementedException();
        }
    }
}