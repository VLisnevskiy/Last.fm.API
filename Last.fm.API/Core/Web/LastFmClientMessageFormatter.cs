﻿//-----------------------------------------------------------------------
// <copyright file="LastFmClientMessageFormatter.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Last.fm.API.Core.Web
{
    internal class LastFmClientMessageFormatter : IClientMessageFormatter
    {
        private readonly IClientMessageFormatter innerFormater;

        private readonly OperationDescription operation;
        private readonly ServiceEndpoint endpoint;

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

        /// <summary>
        /// Converts an <see cref="T:System.Object"/> array into an outbound <see cref="T:System.ServiceModel.Channels.Message"/>. 
        /// </summary>
        /// <returns>
        /// The SOAP message sent to the service operation.
        /// </returns>
        /// <param name="messageVersion">The version of the SOAP message to use.</param>
        /// <param name="parameters">The parameters passed to the  client operation.</param>
        public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
        {
            Message message = innerFormater.SerializeRequest(messageVersion, parameters);
            //HttpRequestMessageProperty request = (HttpRequestMessageProperty) message.Properties[HttpRequestMessageProperty.Name];
            //if (null != request)
            //{
            //}

            return message;
        }

        /// <summary>
        /// Converts a message into a return value and out parameters that are passed back to the calling operation.
        /// </summary>
        /// <returns>
        /// The return value of the operation.
        /// </returns>
        /// <param name="message">The inbound message.</param>
        /// <param name="parameters">Any out values.</param>
        public object DeserializeReply(Message message, object[] parameters)
        {
            if (null != operation)
            {
                Type returnType = operation.SyncMethod.ReturnType;
                if (BaseResponse.IsBaseResponse(returnType))
                {
                    return BaseResponse.DeserializeMessage(message, returnType);
                }
            }

            return innerFormater.DeserializeReply(message, parameters);
        }
    }
}