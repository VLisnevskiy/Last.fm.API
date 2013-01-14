using System;
using System.ServiceModel.Dispatcher;

namespace Last.fm.API.BaseLastFm
{
    internal class LastFmQueryStringConverter : QueryStringConverter
    {
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

            return base.CanConvert(type);
        }

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

            return base.ConvertStringToValue(parameter, parameterType);
        }

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

            return base.ConvertValueToString(parameter, parameterType);
        }
    }
}