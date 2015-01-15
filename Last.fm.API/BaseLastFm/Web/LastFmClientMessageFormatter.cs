using System;
using System.IO;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;

namespace Last.fm.API.BaseLastFm.Web
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
                if (typeof (BaseResponse) == returnType)
                {
                    BaseResponse response = BaseResponse.CreateInstance();
                    response.InnerXml = ExtractInnerXmlAndNormalize(ref message);

                    return response;
                }

                if (returnType.BaseType == typeof (BaseResponse))
                {
                    return ProcessReplyBeforeDeserialization(message, parameters);
                }
            }

            return innerFormater.DeserializeReply(message, parameters);
        }

        private object ProcessReplyBeforeDeserialization(Message message, object[] parameters)
        {
            string innerXml = ExtractInnerXmlAndNormalize(ref message);
            object results = innerFormater.DeserializeReply(message, parameters);
            BaseResponse response = results as BaseResponse;
            if (response != null)
            {
                response.InnerXml = innerXml;
            }

            return results;
        }

        private string ExtractInnerXmlAndNormalize(ref Message message)
        {
            string innerXml;
            using (MessageBuffer buffer = message.CreateBufferedCopy(int.MaxValue))
            {
                message = buffer.CreateMessage();
                StringBuilder sb = new StringBuilder();

                #region XmlWriterSettings

                Encoding encoding = Encoding.UTF8;
                XmlWriterSettings writerSettings = new XmlWriterSettings
                {
                    Encoding = encoding,
                    ConformanceLevel = ConformanceLevel.Auto,
                    OmitXmlDeclaration = true,
                    CloseOutput = false
                };

                #endregion XmlWriterSettings

                #region Write Response to XmlWriter

                using (XmlWriter writer = XmlWriter.Create(sb, writerSettings))
                {
                    message.WriteMessage(writer);
                    writer.Flush();
                }

                #endregion Write Response to XmlWriter

                #region Modify message and extract innerXml

                innerXml = BaseResponse.ExtractLfmStatusToString(sb.ToString());

                #endregion Modify message and extract innerXml

                #region Creaate Message with modification

                MemoryStream ms = new MemoryStream(encoding.GetBytes(innerXml));
                XmlReader bodyReader = XmlReader.Create(ms);
                message = buffer.CreateMessage();
                message = Message.CreateMessage(message.Version, message.Headers.Action, bodyReader);
                message.Headers.CopyHeadersFrom(message);

                #endregion Creaate Message with modification

                innerXml = string.Format("{0}{1}", Constants.XmlDocumentHeader, innerXml);
            }

            return innerXml;
        }

    }
}