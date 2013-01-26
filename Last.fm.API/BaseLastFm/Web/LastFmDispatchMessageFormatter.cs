using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Last.fm.API.BaseLastFm.Web
{
    internal class LastFmDispatchMessageFormatter : IDispatchMessageFormatter
    {
        private readonly IDispatchMessageFormatter innerFormater;

        private OperationDescription operation;
        private ServiceEndpoint endpoint;

        public LastFmDispatchMessageFormatter(IDispatchMessageFormatter original)
        {
            innerFormater = original;
        }

        public LastFmDispatchMessageFormatter(IDispatchMessageFormatter original,
                                              OperationDescription operation, ServiceEndpoint endpoint)
            : this(original)
        {
            this.endpoint = endpoint;
            this.operation = operation;
        }

        /// <summary>
        /// Deserializes a message into an array of parameters.
        /// </summary>
        /// <param name="message">The incoming message.</param>
        /// <param name="parameters">The objects that are passed to the operation as parameters.</param>
        public void DeserializeRequest(Message message, object[] parameters)
        {
            innerFormater.DeserializeRequest(message, parameters);
        }

        /// <summary>
        /// Serializes a reply message from a specified message version, array of parameters, and a return value.
        /// </summary>
        /// <returns>
        /// The serialized reply message.
        /// </returns>
        /// <param name="messageVersion">The SOAP message version.</param>
        /// <param name="parameters">The out parameters.</param><param name="result">The return value.</param>
        public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
        {
            return innerFormater.SerializeReply(messageVersion, parameters, result);
        }
    }
}