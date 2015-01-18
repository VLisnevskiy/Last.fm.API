//-----------------------------------------------------------------------
// <copyright file="LastFmWebHttpBehavior.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Last.fm.API.Core.Web
{
    /// <summary>
    /// Enables the Web programming model for a  service.
    /// </summary>
    internal sealed class LastFmWebHttpBehavior : WebHttpBehavior
    {
        public LastFmWebHttpBehavior()
        {
            FaultExceptionEnabled = true;
        }

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

        public override void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            base.ApplyClientBehavior(endpoint, clientRuntime);

            foreach (IClientMessageInspector messageInspector in clientRuntime.MessageInspectors)
            {
                if (messageInspector is LastFmClientMessageInspector)
                {
                    return;
                }
            }

            clientRuntime.MessageInspectors.Add(new LastFmClientMessageInspector());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="endpointDispatcher"></param>
        public override void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            base.ApplyDispatchBehavior(endpoint, endpointDispatcher);

            foreach (IErrorHandler errorHandler in endpointDispatcher.ChannelDispatcher.ErrorHandlers)
            {
                if (errorHandler is LastFmErrorHandler)
                {
                    return;
                }
            }

            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(new LastFmErrorHandler());
        }

        protected override void AddServerErrorHandlers(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            base.AddServerErrorHandlers(endpoint, endpointDispatcher);

            foreach (IErrorHandler errorHandler in endpointDispatcher.ChannelDispatcher.ErrorHandlers)
            {
                if (errorHandler is LastFmErrorHandler)
                {
                    return;
                }
            }

            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(new LastFmErrorHandler());
        }
    }
}