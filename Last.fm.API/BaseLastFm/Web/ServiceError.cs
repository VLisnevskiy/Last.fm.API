using System.Xml.Serialization;

namespace Last.fm.API.BaseLastFm.Web
{
    /// <summary>
    /// Class ServiceError
    /// </summary>
    [XmlRoot("error", IsNullable = true)]
    public class ServiceError : BaseResponse
    {
        /// <summary>
        /// Create an new instance of ServiceError
        /// </summary>
        public ServiceError()
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
                if (!string.IsNullOrEmpty(value))
                {
                    message = value.Trim();
                }
            }
        }
    }
}
