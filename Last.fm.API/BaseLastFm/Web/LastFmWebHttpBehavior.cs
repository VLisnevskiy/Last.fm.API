using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Last.fm.API.BaseLastFm.Web
{
    /// <summary>
    /// Enables the Web programming model for a  service.
    /// </summary>
    public class LastFmWebHttpBehavior : WebHttpBehavior
    {
        /// <summary>
        /// Gets the query string converter.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.ServiceModel.Dispatcher.QueryStringConverter"/> instance.
        /// </returns>
        /// <param name="operationDescription">The service operation.</param>
        protected override QueryStringConverter GetQueryStringConverter(OperationDescription operationDescription)
        {
            return new LastFmQueryStringConverter();
        }

        /// <summary>
        /// Gets the request formatter on the client for the specified service operation and endpoint.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.ServiceModel.Dispatcher.IClientMessageFormatter"/> reference to the request formatter on the client for the specified operation and endpoint.
        /// </returns>
        /// <param name="operationDescription">The service operation.</param>
        /// <param name="endpoint">The service endpoint.</param>
        protected override IClientMessageFormatter GetRequestClientFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
        {
            IClientMessageFormatter formatter = base.GetRequestClientFormatter(operationDescription, endpoint);
            return new LastFmClientMessageFormatter(formatter, operationDescription, endpoint);
        }

        /// <summary>
        /// Gets the reply formatter on the client for the specified endpoint and service operation.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.ServiceModel.Dispatcher.IClientMessageFormatter"/> reference to the reply formatter on the client for the specified operation and endpoint.
        /// </returns>
        /// <param name="operationDescription">The service operation.</param>
        /// <param name="endpoint">The service endpoint.</param>
        protected override IClientMessageFormatter GetReplyClientFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
        {
            IClientMessageFormatter formatter = base.GetReplyClientFormatter(operationDescription, endpoint);
            return new LastFmClientMessageFormatter(formatter, operationDescription, endpoint);
        }

        /// <summary>
        /// Gets the reply formatter on the service for the specified endpoint and service operation.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.ServiceModel.Dispatcher.IDispatchMessageFormatter"/> reference to the reply formatter on the service for the specified operation and endpoint.
        /// </returns>
        /// <param name="operationDescription">The service operation.</param>
        /// <param name="endpoint">The service endpoint.</param>
        protected override IDispatchMessageFormatter GetReplyDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
        {
            IDispatchMessageFormatter formatter = base.GetReplyDispatchFormatter(operationDescription, endpoint);
            return new LastFmDispatchMessageFormatter(formatter, operationDescription, endpoint);
        }

    }
}