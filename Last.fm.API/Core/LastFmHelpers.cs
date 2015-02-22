//-----------------------------------------------------------------------
// <copyright file="LastFmHelpers.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Last.fm.API.Core.Web;
using TimeSpan = System.TimeSpan;

namespace Last.fm.API.Core
{
    /// <summary>
    /// Helpers
    /// </summary>
    public static class LastFmHelpers
    {
        #region Convertation

        /// <summary>
        /// Method for converting a System.DateTime value to a UNIX Timestamp
        /// </summary>
        /// <param name="value">date to convert</param>
        /// <returns>UNIX Timestamp</returns>
        public static double ToTimestamp(this DateTime value)
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            //return the total seconds (which is a UNIX timestamp)
            return span.TotalSeconds;
        }

        /// <summary>
        /// Method for converting a System.DateTime value to a UNIX Timestamp
        /// </summary>
        /// <param name="value">date to convert</param>
        /// <returns>UNIX Timestamp</returns>
        public static double? ToTimestamp(this DateTime? value)
        {
            if (value != null)
            {
                DateTime locValue = (DateTime) value;
                //create Timespan by subtracting the value provided from
                //the Unix Epoch
                TimeSpan span = (locValue - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
                //return the total seconds (which is a UNIX timestamp)
                return span.TotalSeconds;
            }

            return null;
        }

        #endregion

        #region Reflaction

        /// <summary>
        /// Get custom attribute from parameter info <see cref="T:System.Reflection.ParameterInfo"/>.
        /// </summary>
        /// <typeparam name="TAttribute">Type of attribute.</typeparam>
        /// <param name="parameter">Parameter info.</param>
        /// <returns>Return attribute.</returns>
        public static TAttribute GetAttribute<TAttribute>(this ParameterInfo parameter)
        {
            return parameter.GetCustomAttributes(typeof (TAttribute), false)
                .Cast<TAttribute>()
                .FirstOrDefault();
        }

        /// <summary>
        /// Get custom attribute from method <see cref="T:System.Reflection.MethodBase"/>.
        /// </summary>
        /// <typeparam name="TAttribute">Type of attribute.</typeparam>
        /// <param name="method">Method.</param>
        /// <param name="inherit">true to search this member's inheritance chain to
        /// find the attributes; otherwise, false.</param>
        /// <returns>Return attribute.</returns>
        public static TAttribute GetAttribute<TAttribute>(this MethodBase method, bool inherit)
        {
            return method.GetCustomAttributes(typeof (TAttribute), inherit)
                .Cast<TAttribute>()
                .FirstOrDefault();
        }

        /// <summary>
        /// Get custom attribute from method <see cref="T:System.Type"/>.
        /// </summary>
        /// <typeparam name="TAttribute">Type of attribute.</typeparam>
        /// <param name="type">Method.</param>
        /// <param name="inherit">true to search this member's inheritance chain to
        /// find the attributes; otherwise, false.</param>
        /// <returns>Return attribute.</returns>
        public static TAttribute GetAttribute<TAttribute>(this Type type, bool inherit)
        {
            return type.GetCustomAttributes(typeof (TAttribute), inherit)
                .Cast<TAttribute>()
                .FirstOrDefault();
        }

        /// <summary>
        /// Get custom attribute from method <see cref="T:System.Reflection.PropertyInfo"/>.
        /// </summary>
        /// <typeparam name="TAttribute">Type of attribute.</typeparam>
        /// <param name="property">Method.</param>
        /// <param name="inherit">true to search this member's inheritance chain to
        /// find the attributes; otherwise, false.</param>
        /// <returns>Return attribute.</returns>
        public static TAttribute GetAttribute<TAttribute>(this PropertyInfo property, bool inherit)
        {
            return property.GetCustomAttributes(typeof (TAttribute), inherit)
                .Cast<TAttribute>()
                .FirstOrDefault();
        }

        #endregion

        #region Extract and set

        /// <summary>
        /// Get value from Setting Element.
        /// </summary>
        /// <param name="settingElement">Input setting element.</param>
        /// <returns>Return string value.</returns>
        public static string GetValue(this SettingElement settingElement)
        {
            if (null != settingElement && null != settingElement.Value)
            {
                return settingElement.Value.ValueXml.InnerText.Trim();
            }

            return null;
        }

        /// <summary>
        /// Set value for Setting Element.
        /// </summary>
        /// <param name="settingElement">Input setting element.</param>
        /// <param name="value">Value.</param>
        public static void SetValue(this SettingElement settingElement, object value)
        {
            if (null != settingElement && null != value)
            {
                settingElement.Value = new SettingValueElement();
                XElement xmlElement = new XElement(XName.Get("value"));
                XmlDocument doc = new XmlDocument();
                settingElement.Value.ValueXml = doc.ReadNode(xmlElement.CreateReader());
                if (null != settingElement.Value.ValueXml)
                {
                    settingElement.Value.ValueXml.InnerText = value.ToString();
                }
            }
        }

        /// <summary>
        /// Extract elements of type TResult from xml.
        /// </summary>
        /// <typeparam name="TResult">Type of returned elements.</typeparam>
        /// <param name="elements">Collection of xml elements/</param>
        /// <returns>Collection of extracted items.</returns>
        public static List<TResult> ExtracktItems<TResult>(this IEnumerable<XElement> elements)
            where TResult : class, new()
        {
            List<TResult> items = new List<TResult>();
            XmlSerializer serializer = new XmlSerializer(typeof (TResult));
            foreach (XElement element in elements)
            {
                using (Stream stream = new MemoryStream())
                {
                    element.Save(stream);
                    stream.Position = 0;
                    TResult item = serializer.Deserialize(stream) as TResult;
                    if (null != item)
                    {
                        items.Add(item);
                    }
                }
            }

            return items;
        }

        /// <summary>
        /// Extract elements of type TResult from xml.
        /// </summary>
        /// <typeparam name="TResult">Type of returned elements.</typeparam>
        /// <param name="rootElement">Collection of xml elements.</param>
        /// <param name="name">Name of element.</param>
        /// <returns>Collection of extracted items.</returns>
        public static List<TResult> ExtracktItems<TResult>(this XElement rootElement, string name)
            where TResult : class, new()
        {
            return rootElement.Elements(name).ExtracktItems<TResult>();
        }

        /// <summary>
        /// Get value of xml attribute.
        /// </summary>
        /// <typeparam name="TResult">Type of results.</typeparam>
        /// <param name="element">Input element.</param>
        /// <param name="name">Name of attribute.</param>
        /// <returns>Return value of attribute.</returns>
        public static TResult GetAttributeValue<TResult>(this XElement element, string name)
        {
            TResult result = default(TResult);
            LastFmQueryStringConverter converter = new LastFmQueryStringConverter();
            XAttribute attribute = element.Attribute(name);
            if (null != attribute)
            {
                if (converter.CanConvert(typeof (TResult)))
                {
                    result = converter.ConvertStringToValue<TResult>(attribute.Value);
                }
            }

            return result;
        }

        /// <summary>
        /// Get value of xml element.
        /// </summary>
        /// <typeparam name="TResult">Type of results.</typeparam>
        /// <param name="rootElement">Input element.</param>
        /// <param name="name">Name of attribute.</param>
        /// <returns>Return value of attribute.</returns>
        public static TResult GetValue<TResult>(this XElement rootElement, string name)
        {
            TResult result = default(TResult);
            LastFmQueryStringConverter converter = new LastFmQueryStringConverter();
            XElement element = rootElement.Element(name);
            if (null != element)
            {
                if (converter.CanConvert(typeof (TResult)))
                {
                    result = converter.ConvertStringToValue<TResult>(element.Value);
                }
            }

            return result;
        }

        #endregion

        #region md5 - Hash

        /// <summary>
        /// md5 hasing.
        /// </summary>
        /// <param name="parameters">Input string.</param>
        /// <returns>32-character hexadecimal md5 hash.</returns>
        public static string MD5(this string parameters)
        {
            string res = string.Empty;
            foreach (byte b in MD5Bytes(parameters))
            {
                res += b.ToString("x2");
            }

            return res;
        }

        /// <summary>
        /// md5 hasing.
        /// </summary>
        /// <param name="parameters">Input string.</param>
        /// <returns>32-character hexadecimal md5 hash.</returns>
        public static byte[] MD5Bytes(this string parameters)
        {
            byte[] hash = new MD5CryptoServiceProvider()
                .ComputeHash(Encoding.UTF8.GetBytes(parameters));

            return hash;
        }

        #endregion
    }
}