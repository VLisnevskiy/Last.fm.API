//-----------------------------------------------------------------------
// <copyright file="ErrorMessage.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace Last.fm.API.Core.Types
{
    /// <summary>
    /// Class ErrorMessage
    /// </summary>
    [XmlRoot("error")]
    public class ErrorMessage : BaseResponse
    {
        /// <summary>
        /// Create an new instance of ErrorMessage
        /// </summary>
        public ErrorMessage()
        {
            Code = 0;
            message = Constants.Ok;
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

        #region Overrided

        public override string ToString()
        {
            return string.Format("Code [{0}] : - {1}",
                Code,
                Message);
        }

        #endregion
    }
}
