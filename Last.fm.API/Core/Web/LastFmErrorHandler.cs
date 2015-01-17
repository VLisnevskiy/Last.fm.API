//-----------------------------------------------------------------------
// <copyright file="LastFmErrorHandler.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Last.fm.API.Core.Web
{
    internal class LastFmErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            if (error is FaultException)
            {
                return false; // Let WCF do normal processing
            }
            else
            {
                return true; // Fault message is already generated
            }
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is FaultException)
            {
                // Let WCF do normal processing
            }
            else
            {
                // Generate fault message manually
                MessageFault messageFault = MessageFault.CreateFault(
                    new FaultCode("Sender"),
                    new FaultReason(error.Message),
                    error,
                    new NetDataContractSerializer());
                fault = Message.CreateMessage(version, messageFault, null);
            }
        }
    }
}