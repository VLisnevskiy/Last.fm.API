//-----------------------------------------------------------------------
// <copyright file="TimeSpan.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Last.fm.API.Core.Types
{
    /// <summary>
    /// Wraper for System.TimeSpan
    /// </summary>
    public struct TimeSpan : IXmlSerializable
    {
        private System.TimeSpan _value;

        public System.TimeSpan Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// Initializes a new Last.fm.API.Core.Types.TimeSpan to the specified number of ticks.
        /// </summary>
        /// <param name="ticks">A time period expressed in 100-nanosecond units.</param>
        public TimeSpan(long ticks)
        {
            _value = new System.TimeSpan(ticks);
        }

        /// <summary>
        /// Initializes a new Last.fm.API.Core.Types.TimeSpan to a specified number of hours, minutes,
        /// and seconds.
        /// </summary>
        /// <param name="hours">Number of hours.</param>
        /// <param name="minutes">Number of minutes.</param>
        /// <param name="seconds">Number of seconds.</param>
        public TimeSpan(int hours, int minutes, int seconds)
        {
            _value = new System.TimeSpan(hours, minutes, seconds);
        }

        /// <summary>
        /// Initializes a new Last.fm.API.Core.Types.TimeSpan to a specified number of days, hours, minutes,
        /// and seconds.
        /// </summary>
        /// <param name="days">Number of days.</param>
        /// <param name="hours">Number of hours.</param>
        /// <param name="minutes">Number of minutes.</param>
        /// <param name="seconds">Number of seconds.</param>
        public TimeSpan(int days, int hours, int minutes, int seconds)
        {
            _value = new System.TimeSpan(days, hours, minutes, seconds);
        }

        /// <summary>
        /// Initializes a new Last.fm.API.Core.Types.TimeSpan to a specified number of days, hours, minutes,
        /// seconds, and milliseconds.
        /// </summary>
        /// <param name="days">Number of days.</param>
        /// <param name="hours">Number of hours.</param>
        /// <param name="minutes">Number of minutes.</param>
        /// <param name="seconds">Number of seconds.</param>
        /// <param name="milliseconds">Number of milliseconds.</param>
        public TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds)
        {
            _value = new System.TimeSpan(days, hours, minutes, seconds, milliseconds);
        }

        /// <summary>
        /// Implicit cast to string from LfmString
        /// </summary>
        /// <param name="value">Input System.TimeSpan object value</param>
        /// <returns>Output Last.fm.API.Core.Types.TimeSpan object</returns>
        public static implicit operator TimeSpan(System.TimeSpan value)
        {
            return new TimeSpan { Value = value };
        }

        /// <summary>
        /// Implicit cast to string from LfmString
        /// </summary>
        /// <param name="value">Input System.String object value</param>
        /// <returns>Output Last.fm.API.Core.Types.TimeSpan object</returns>
        public static implicit operator TimeSpan(System.String value)
        {
            return new TimeSpan { Value = System.TimeSpan.Parse(value) };
        }

        /// <summary>
        /// Implicit cast to string from LfmString
        /// </summary>
        /// <param name="value">Input Last.fm.API.Core.Types.TimeSpan object value</param>
        /// <returns>Output System.TimeSpan object</returns>
        public static implicit operator System.TimeSpan(TimeSpan value)
        {
            return value._value;
        }

        #region IXmlSerializable

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable
        /// interface, you should return null (Nothing in Visual Basic) from this method,
        /// and instead, if specifying a custom schema is required, apply the System.Xml.Serialization.XmlSchemaProviderAttribute
        /// to the class.
        /// </summary>
        /// <returns>
        /// An System.Xml.Schema.XmlSchema that describes the XML representation of the
        /// object that is produced by the System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)
        /// method and consumed by the System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)
        /// method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The System.Xml.XmlReader stream from which the object is deserialized.</param>
        public void ReadXml(XmlReader reader)
        {
            string value = reader.ReadElementString(reader.Name);
            _value = System.TimeSpan.Parse(value);
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The System.Xml.XmlWriter stream to which the object is serialized.</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteValue(_value.ToString());
        }

        #endregion

        #region Overrided

        public override string ToString()
        {
            return Value.ToString();
        }

        #endregion
    }
}