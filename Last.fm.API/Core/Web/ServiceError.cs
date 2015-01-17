//-----------------------------------------------------------------------
// <copyright file="ServiceError.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;
using Last.fm.API.Core;

namespace Last.fm.API.BaseLastFm.Web
{
    /// <summary>
    /// Class ServiceError
    /// </summary>
    [XmlRoot("error")]
    public class ServiceError : BaseResponse
    {
        /// <summary>
        /// Create an new instance of ServiceError
        /// </summary>
        public ServiceError()
        {
            Code = 0;
        }

        /// <summary>
        /// Code
        /// </summary>
        [XmlAttribute("code")]
        public int Code { get; set; }

        private string message = Constants.Ok;

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
