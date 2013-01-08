using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Last.fm.API.BaseLastFm
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("error", IsNullable = true)]
    public class ServicesError
    {
        public ServicesError()
        {
            Code = 0;
            Message = "Ok";
        }

        [XmlAttribute("code")]
        public int Code { get; set; }

        private string message;

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
