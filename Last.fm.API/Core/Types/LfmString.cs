//-----------------------------------------------------------------------
// <copyright file="LfmString.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace Last.fm.API.Core.Types
{
    /// <summary>
    /// LfmString
    /// </summary>
    public class LfmString
    {
        /// <summary>
        /// String value
        /// </summary>
        [XmlText]
        public string Value { get; set; }

        /// <summary>
        /// Indicate if value was corrected.
        /// </summary>
        [XmlAttribute("corrected")]
        public bool Corrected { get; set; }

        /// <summary>
        /// Constructor of LfmString. Create new instance.
        /// </summary>
        public LfmString()
        {
            Corrected = false;
        }

        /// <summary>
        /// Constructor of LfmString. Create new instance.
        /// </summary>
        /// <param name="value">Input value</param>
        public LfmString(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Constructor of LfmString. Create new instance.
        /// </summary>
        /// <param name="value">Input value</param>
        /// <param name="corrected">Indicate if was corrected</param>
        public LfmString(string value, bool corrected)
        {
            Value = value;
            Corrected = corrected;
        }

        /// <summary>
        /// Implicit cast to string from LfmString
        /// </summary>
        /// <param name="input">Input LfmString object value</param>
        /// <returns>Output string object</returns>
        public static implicit operator string(LfmString input)
        {
            if (null == input)
            {
                return string.Empty;
            }
            else
            {
                return input.Value;
            }
        }

        /// <summary>
        /// Implicit cast to LfmString from string
        /// </summary>
        /// <param name="input">Input string value</param>
        /// <returns>Output LfmString object</returns>
        public static implicit operator LfmString(string input)
        {
            return new LfmString(input, false);
        }

        #region Overrided

        public override string ToString()
        {
            return string.Format("{0}", Value);
        }

        #endregion
    }
}
