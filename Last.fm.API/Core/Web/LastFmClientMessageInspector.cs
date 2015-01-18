//-----------------------------------------------------------------------
// <copyright file="LastFmClientMessageInspector.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Last.fm.API.Core.Types;

namespace Last.fm.API.Core.Web
{
    internal class LastFmClientMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            if (reply.IsFault)
            {
                throw LastFmException.CreateException(reply.ToString(),
                    BaseResponse.DeserializeMessage(reply, typeof (ErrorMessage)) as ErrorMessage);
            }
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            //:TODO - Maybe will be implemented sometime
            /*HttpRequestMessageProperty httpRequest = request.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            if (null != httpRequest)
            {

            }*/

            return null;
        }
    }
}