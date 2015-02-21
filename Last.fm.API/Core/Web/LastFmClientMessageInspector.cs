//-----------------------------------------------------------------------
// <copyright file="LastFmClientMessageInspector.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using Last.fm.API.Core.Types;

namespace Last.fm.API.Core.Web
{
    internal class LastFmClientMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            if (reply.IsFault)
            {
                throw LastFmException.CreateException(reply.ToString(),
                    BaseResponse.DeserializeMessage(reply, typeof (ErrorMessage)) as ErrorMessage);
            }
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel)
        {
            return null;
        }
    }
}