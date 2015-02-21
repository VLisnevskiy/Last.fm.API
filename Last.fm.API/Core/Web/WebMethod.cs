//-----------------------------------------------------------------------
// <copyright file="WebMethod.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Last.fm.API.Core.Web
{
    /// <summary>
    /// Last.fm web method.
    /// </summary>
    public class WebMethod
    {
        /// <summary>
        /// Http method type. GET or POST.
        /// </summary>
        public HttpMethod Method { get; protected set; }

        /// <summary>
        /// Name of web method.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Method info <see cref="T:System.Reflection.MethodInfo"/>.
        /// </summary>
        public MethodInfo MethodInfo { get; protected set; }

        /// <summary>
        /// Type of method results.
        /// </summary>
        public Type ReturnType { get; protected set; }

        /// <summary>
        /// Collection of paramters name.
        /// </summary>
        public List<string> Params { get; protected set; }

        /// <summary>
        /// Value of parameters.
        /// </summary>
        protected object[] ParamsValue { get; set; }

        /// <summary>
        /// Create an instance of WebMethod.
        /// </summary>
        /// <param name="methodInfo">Method info <see cref="T:System.Reflection.MethodInfo"/>.</param>
        /// <param name="method">Method of web request.</param>
        /// <param name="name">Name of web method.</param>
        public WebMethod(MethodInfo methodInfo, HttpMethod method, string name)
        {
            MethodInfo = methodInfo;
            Method = method;
            Name = name;
            ReturnType = methodInfo.ReturnType;
            ExtractParamters();
        }

        /// <summary>
        /// Create an instance of WebMethod.
        /// </summary>
        /// <param name="methodInfo">Method info <see cref="T:System.Reflection.MethodInfo"/>.</param>
        /// <param name="attribute">Web method attribute.</param>
        public WebMethod(MethodInfo methodInfo, WebMethodAttribute attribute)
        {
            MethodInfo = methodInfo;
            Method = attribute.Method;
            Name = attribute.Name;
            ReturnType = methodInfo.ReturnType;
            ExtractParamters();
        }

        /// <summary>
        /// Extract parameters from method info.
        /// </summary>
        protected void ExtractParamters()
        {
            Params = new List<string>();
            foreach (ParameterInfo parameter in MethodInfo.GetParameters())
            {
                string paramName = parameter.Name;
                ParameterAttribute lfmParam = parameter.GetAttribute<ParameterAttribute>();
                if (null != lfmParam)
                {
                    paramName = lfmParam.Name;
                }

                Params.Add(paramName);
            }
        }

        /// <summary>
        /// Set value for parameters.
        /// </summary>
        /// <param name="values">Collection of values.</param>
        public void SetParamsValue(object[] values)
        {
            if (null == values)
            {
                throw new ArgumentNullException("values", "Parameter can't be null");
            }

            ParamsValue = values;
        }

        /// <summary>
        /// Get request body.
        /// </summary>
        /// <returns>Return request body.</returns>
        public string GetRequestBody()
        {
            string message = string.Format("{0}method={1}",
                Method == HttpMethod.GET ? "?" : "",
                Name);
            if (null != ParamsValue && ParamsValue.Length > 0)
            {
                string paramPatern = string.Empty;
                for (int i = 0; i < Params.Count; i++)
                {
                    paramPatern += string.Format("&{0}={1}",
                        Params[i],
                        "{" + i + "}");
                }

                message = string.Format("{0}{1}", message, paramPatern);
                return string.Format(message, ParamsValue);
            }

            return message;
        }

        #region Overrided

        public override string ToString()
        {
            return string.Format("Method = [{0}] : {1}",
                Name,
                Method);
        }

        #endregion
    }
}