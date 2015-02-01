//-----------------------------------------------------------------------
// <copyright file="LastFmClientMessageInspector.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Net;
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

            //if (reply != null)
            //{
            //    HttpResponseMessageProperty prop = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
            //    if (prop != null && prop.StatusCode == HttpStatusCode.InternalServerError)
            //    {
            //        //throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(prop.StatusDescription));
            //    }
            //}
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            //:TODO - Maybe will be implemented sometime
            //HttpRequestMessageProperty httpRequest = request.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            //if (null != httpRequest)
            //{
            //
            //}

            return null;
        }
    }
}