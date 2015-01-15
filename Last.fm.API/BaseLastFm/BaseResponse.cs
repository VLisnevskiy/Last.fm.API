using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Last.fm.API.BaseLastFm
{
    /// <summary>
    /// Base Response from Last.fm
    /// </summary>
    public abstract class BaseResponse
    {
        /// <summary>
        /// Inner XML text
        /// </summary>
        [XmlIgnore]
        public string InnerXml { get; internal set; }

        /// <summary>
        /// Status of Last.fm response
        /// </summary>
        [XmlAttribute("status")]
        public LfmStatus Status { get; set; }

        #region Create instance

        private class BaseResponseImpl : BaseResponse
        {
            public BaseResponseImpl()
            {
                Status = LfmStatus.ok;
            }
        }

        internal static BaseResponse CreateInstance()
        {
            BaseResponse empty = new BaseResponseImpl();
            return empty;
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
            return ExtractLfmStatusToString(XElement.Load(stream));
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
            return ExtractLfmStatusToStream(XElement.Load(stream));
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

                XAttribute statusAttribute;
                if (rootElement.HasAttributes)
                {
                    statusAttribute = rootElement.Attribute(Constants.StatusAttribute);
                }
                else
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
    }
}
