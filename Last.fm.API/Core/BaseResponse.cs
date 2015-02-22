//-----------------------------------------------------------------------
// <copyright file="BaseResponse.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.IO;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Last.fm.API.Core.Types;

namespace Last.fm.API.Core
{
    /// <summary>
    /// Base Response from Last.fm
    /// </summary>
    public abstract class BaseResponse : LikeObject
    {
        /// <summary>
        /// Inner XML text
        /// </summary>
        [XmlIgnore]
        public string InnerXml { get; internal set; }

        /// <summary>
        /// Success of Last.fm response
        /// </summary>
        [XmlAttribute("status")]
        public LfmStatus Success { get; set; }

        protected BaseResponse()
        {
            Success = LfmStatus.ok;
        }

        #region Create instance

        private class BaseResponseImpl : BaseResponse
        {
            public BaseResponseImpl()
            {
                Success = LfmStatus.ok;
            }
        }

        internal static BaseResponse CreateInstance()
        {
            BaseResponse empty = new BaseResponseImpl();
            return empty;
        }

        #endregion

        #region Deserialization

        internal static TResult Deserialize<TResult>(Stream stream) where TResult : BaseResponse, new()
        {
            XDocument doc;
            stream = ExtractLfmStatusToStream(stream, out doc);
            TResult result = new TResult();

            if (stream != null)
            {
                stream.Position = 0;
                XmlSerializer serializer = new XmlSerializer(typeof(TResult));
                result = (TResult)serializer.Deserialize(stream);
                result.InnerXml = string.Format("{0}{1}", Constants.XmlDocumentHeader, doc);
            }

            return result;
        }

        internal static object Deserialize(Stream stream, Type type)
        {
            object result;
            XDocument doc;
            stream = ExtractLfmStatusToStream(stream, out doc);

            if (typeof(BaseResponse) == type)
            {
                result = new BaseResponseImpl
                {
                    InnerXml = doc.ToString(),
                    Success = LfmStatus.ok
                };

                return result;
            }

            stream.Position = 0;
            XmlSerializer serializer = new XmlSerializer(type);
            result = serializer.Deserialize(stream);
            ((BaseResponse) result).InnerXml =
                string.Format("{0}{1}", Constants.XmlDocumentHeader, doc);

            return result;
        }

        #endregion

        #region Process Messages

        internal static bool IsBaseResponse(Type type)
        {
            if (null != type)
            {
                if (typeof (BaseResponse) == type)
                {
                    return true;
                }

                return IsBaseResponse(type.BaseType);
            }

            return false;
        }

        internal static object DeserializeMessage(Message message, Type type)
        {
            object result = null;
            XDocument doc = ExtractInnerXmlAndNormalize(ref message);

            if (null != doc)
            {
                if (typeof (BaseResponse) == type)
                {
                    result = new BaseResponseImpl
                    {
                        InnerXml = doc.ToString(),
                        Success = LfmStatus.ok
                    };

                    return result;
                }

                if (IsItError(doc, type))
                {
                    result = new ErrorMessage
                    {
                        Code = 999,
                        Message = Constants.ReceivedBadRequestMsg,
                        InnerXml = doc.ToString(),
                        Success = LfmStatus.failed
                    };
                    return result;
                }

                Stream stream = new MemoryStream();
                doc.Save(stream);
                stream.Position = 0;
                XmlSerializer serializer = new XmlSerializer(type);

                result = serializer.Deserialize(stream);
                ((BaseResponse) result).InnerXml =
                    string.Format("{0}{1}", Constants.XmlDocumentHeader, doc);
            }

            return result;
        }

        private static bool IsItError(XDocument doc, Type type)
        {
            if (typeof (ErrorMessage) == type)
            {
                return null != doc &&
                    null != doc.Root &&
                    !Constants.ErrorElement.Equals(doc.Root.Name.ToString());
            }

            return false;
        }

        private static XDocument ExtractInnerXmlAndNormalize(ref Message message)
        {
            XDocument innerXml;
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

                innerXml = ExtractLfmStatus(XElement.Parse(sb.ToString()));

                #endregion Modify message and extract innerXml

                #region Creaate Message with modification

                MemoryStream ms = new MemoryStream(encoding.GetBytes(innerXml.ToString()));
                XmlReader bodyReader = XmlReader.Create(ms);
                message = buffer.CreateMessage();
                message = Message.CreateMessage(message.Version, message.Headers.Action, bodyReader);
                message.Headers.CopyHeadersFrom(message);

                #endregion Creaate Message with modification
            }

            return innerXml;
        }

        #endregion

        #region ExtractLfmStatus

        internal static string ExtractLfmStatusToString(string xml)
        {
            return ExtractLfmStatusToString(XElement.Parse(xml));
        }

        internal static string ExtractLfmStatusToString(XmlReader xmlReader)
        {
            return ExtractLfmStatusToString(XElement.Load(xmlReader));
        }

        internal static string ExtractLfmStatusToString(Stream stream)
        {
            if (null != stream)
            {
                stream.Position = 0;
                return ExtractLfmStatusToString(XElement.Load(stream));
            }

            return null;
        }

        internal static string ExtractLfmStatusToString(XElement rootElement)
        {
            string result = string.Empty;
            XDocument doc = ExtractLfmStatus(rootElement);
            if (null != doc)
            {
                result = doc.ToString();
            }

            return result;
        }

        internal static Stream ExtractLfmStatusToStream(string xml)
        {
            return ExtractLfmStatusToStream(XElement.Parse(xml));
        }

        internal static Stream ExtractLfmStatusToStream(XmlReader xmlReader)
        {
            return ExtractLfmStatusToStream(XElement.Load(xmlReader));
        }

        internal static Stream ExtractLfmStatusToStream(Stream stream)
        {
            if (null != stream)
            {
                stream.Position = 0;
                return ExtractLfmStatusToStream(XElement.Load(stream));
            }

            return null;
        }

        internal static Stream ExtractLfmStatusToStream(Stream stream, out XDocument doc)
        {
            if (null != stream)
            {
                stream.Position = 0;
                return ExtractLfmStatusToStream(XElement.Load(stream), out doc);
            }

            doc = null;
            return null;
        }

        internal static Stream ExtractLfmStatusToStream(XElement rootElement, out XDocument doc)
        {
            Stream stream = new MemoryStream();
            doc = ExtractLfmStatus(rootElement);
            if (null != doc)
            {
                doc.Save(stream);
                return stream;
            }

            return null;
        }

        internal static Stream ExtractLfmStatusToStream(XElement rootElement)
        {
            Stream stream = new MemoryStream();
            XDocument doc = ExtractLfmStatus(rootElement);
            if (null != doc)
            {
                doc.Save(stream);
                return stream;
            }

            return null;
        }

        private static XDocument ExtractLfmStatus(XElement rootElement)
        {
            if (null != rootElement)
            {
                XDocument doc = new XDocument();

                if (!Constants.RootElementLfm.Equals(rootElement.Name.ToString()))
                {
                    doc.Add(rootElement);
                    return doc;
                }

                XAttribute statusAttribute = null;
                if (rootElement.HasAttributes)
                {
                    statusAttribute = rootElement.Attribute(Constants.StatusAttribute);
                }

                if (null == statusAttribute)
                {
                    statusAttribute = new XAttribute(Constants.StatusAttribute, LfmStatus.failed);
                }

                if (rootElement.HasElements)
                {
                    XElement response = XElement.Parse(rootElement.FirstNode.ToString());
                    response.Add(statusAttribute);

                    doc.Add(response);
                }

                return doc;
            }

            return null;
        }

        #endregion

        #region IXmlSerializable

        public override void ReadXml(XDocument doc)
        {
        }

        #endregion

        #region Overrided

        public override string ToString()
        {
            return string.Format("Status [{0}]", Success);
        }

        #endregion
    }
}
