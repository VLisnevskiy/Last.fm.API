//-----------------------------------------------------------------------
// <copyright file="LastFmQueryStringConverter.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.ServiceModel.Dispatcher;

namespace Last.fm.API.Core.Web
{
    /// <summary>
    /// This class converts a parameter in a query string to an object of the appropriate type. It can also convert a parameter from an object to its query string representation.
    /// </summary>
    internal class LastFmQueryStringConverter : QueryStringConverter
    {
        /// <summary>
        /// Determines whether the specified type can be converted to and from a string representation.
        /// </summary>
        /// <returns>
        /// A value that specifies whether the type can be converted.
        /// </returns>
        /// <param name="type">The <see cref="T:System.Type"/> to convert.</param>
        public override bool CanConvert(Type type)
        {
            if (type == typeof(string[]))
            {
                return true;
            }
            if (type == typeof(double?))
            {
                return true;
            }
            if (type == typeof(int?))
            {
                return true;
            }
            if (type == typeof(byte?))
            {
                return true;
            }
            if (type == typeof(bool?))
            {
                return true;
            }

            return base.CanConvert(type);
        }

        /// <summary>
        /// Converts a query string parameter to the specified type.
        /// </summary>
        /// <returns>
        /// The converted parameter.
        /// </returns>
        /// <param name="parameter">The string form of the parameter and value.</param>
        /// <param name="parameterType">The <see cref="T:System.Type"/> to convert the parameter to.</param><exception cref="T:System.FormatException">The provided string does not have the correct format.</exception>
        public override object ConvertStringToValue(string parameter, Type parameterType)
        {
            if (parameterType == typeof(string[]))
            {
                string[] parms = parameter.Split(',');
                return parms;
            }
            if (parameterType == typeof(double?))
            {
                return parameter;
            }
            if (parameterType == typeof(int?))
            {
                return parameter;
            }
            if (parameterType == typeof(byte?))
            {
                return parameter;
            }
            if (parameterType == typeof(bool?))
            {
                return parameter;
            }

            return base.ConvertStringToValue(parameter, parameterType);
        }

        /// <summary>
        /// Converts a parameter to a query string representation.
        /// </summary>
        /// <returns>
        /// The parameter name and value.
        /// </returns>
        /// <param name="parameter">The parameter to convert.</param>
        /// <param name="parameterType">The <see cref="T:System.Type"/> of the parameter to convert.</param>
        public override string ConvertValueToString(object parameter, Type parameterType)
        {
            if (parameterType == typeof(string[]))
            {
                string valstring = string.Join(",", (string[])parameter);
                return valstring;
            }
            if (parameterType == typeof(double?))
            {
                double? val = (double?)parameter;
                return val.ToString();
            }
            if (parameterType == typeof (int?))
            {
                int? val = (int?) parameter;
                return val.ToString();
            }
            if (parameterType == typeof(byte?))
            {
                byte? val = (byte?)parameter;
                return val.ToString();
            }
            if (parameterType == typeof(bool?))
            {
                bool? val = (bool?)parameter;
                if (null == val)
                {
                    return 0.ToString();
                }

                return (val == true ? 1 : 0).ToString();
            }

            return base.ConvertValueToString(parameter, parameterType);
        }
    }
}