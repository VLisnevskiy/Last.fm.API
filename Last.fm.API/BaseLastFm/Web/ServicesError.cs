using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Last.fm.API.BaseLastFm.Web
{
    /// <summary>
    /// Class ServicesError
    /// </summary>
    [XmlType(AnonymousType = true)]
    [XmlRoot("error", IsNullable = true)]
    public class ServicesError
    {
        /// <summary>
        /// Create an new instance of ServicesError
        /// </summary>
        public ServicesError()
        {
            Code = 0;
            Message = "Ok";
        }

        /// <summary>
        /// Code
        /// </summary>
        [XmlAttribute("code")]
        public int Code { get; set; }

        private string message;

        /// <summary>
        /// Message
        /// </summary>
        [XmlText]
        public string Message
        {
            get { return message; }
            set
            {
                message = Regex.Replace(
                    Regex.Replace(value, "\n    ", ""), "\n", "");
            }
        }
    }
}
