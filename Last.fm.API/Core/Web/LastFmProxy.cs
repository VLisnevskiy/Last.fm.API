//-----------------------------------------------------------------------
// <copyright file="LastFmProxy.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.ServiceModel.Dispatcher;
using System.Text;
using Last.fm.API.Core.Settings;

namespace Last.fm.API.Core.Web
{
    /// <summary>
    /// Last.fm proxy class that allow to comunicate with Last.fm web service.
    /// </summary>
    /// <typeparam name="TChannel">Type of services that will be used.</typeparam>
    public class LastFmProxy<TChannel> : RealProxy
    {
        /// <summary>
        /// Url on web service.
        /// </summary>
        public Uri ServiceUrl { get; protected set; }

        /// <summary>
        /// Collections of web methods.
        /// </summary>
        protected Dictionary<MethodBase, WebMethod> Methods { get; private set; }

        /// <summary>
        /// Name of service.
        /// </summary>
        public string ServiceName { get; protected set; }

        /// <summary>
        /// Create an instance of LastFmProxy.
        /// </summary>
        /// <param name="url">Link on Last.fm web service</param>
        public LastFmProxy(Uri url) : base(typeof(TChannel))
        {
            ServiceUrl = url;
            InitializeProxy();
        }

        /// <summary>
        /// Create an instance of LastFmProxy.
        /// </summary>
        public LastFmProxy() : this(new Uri(LastFmSettings.LastFmApiUrl))
        {
        }

        #region Protected part

        /// <summary>
        /// Method that has to initialize client proxy and prepare
        /// methods cache for faster using during executing some of
        /// proxy methods.
        /// </summary>
        protected void InitializeProxy()
        {
            Type chanel = typeof (TChannel);
            ServiceAttribute attribute = chanel.GetAttribute<ServiceAttribute>(false);
            if (null == attribute)
            {
                throw new ArgumentException(string
                    .Format("Interface {0} must have attribute [ServiceAttribute]", chanel.Name));
            }

            ServiceName = attribute.Name;
            Methods = new Dictionary<MethodBase, WebMethod>();
            foreach (MethodInfo method in chanel.GetMethods())
            {
                WebMethodAttribute methodAttribute = method.GetAttribute<WebMethodAttribute>(false);
                if (null != methodAttribute)
                {
                    Methods[method] = new WebMethod(method, methodAttribute);
                }
            }
        }

        /// <summary>
        /// Method that uses for prepareing request.
        /// </summary>
        /// <param name="method">Web method that will be called.</param>
        /// <param name="parameters">Parameters that will be send in request.</param>
        /// <returns>Return request message.</returns>
        protected virtual Message SerializeRequest(WebMethod method, object[] parameters)
        {
            Message message = Message.Create(method, ConvertParams(parameters));
            PrepareRequest(ref message);
            return message;
        }

        /// <summary>
        /// Method that uses for processing response.
        /// </summary>
        /// <param name="message">Message that contains resonse.</param>
        /// <param name="params">Parameters. Currently not used.</param>
        /// <returns>Return deserialized object.</returns>
        protected virtual object DeserializeReply(Message message, object[] @params)
        {
            return BaseResponse.Deserialize(message.ResponseStream, message.Method.ReturnType);
        }

        /// <summary>
        /// Method tha will be called before sending request.
        /// </summary>
        /// <param name="request">Request message.</param>
        protected virtual void BeforeSendRequest(ref Message request)
        {
            //:TODO
        }

        /// <summary>
        /// Method tha will be called after receiving reply.
        /// </summary>
        /// <param name="response">Response message.</param>
        protected virtual void AfterReceiveReply(ref Message response)
        {
            //:TODO
        }

        /// <summary>
        /// Converter. Represent class that uses for converting parameters of request.
        /// </summary>
        protected virtual QueryStringConverter Converter
        {
            get
            {
                return converter ?? (converter = new LastFmQueryStringConverter());
            }
        }

        #endregion

        #region Private part

        private QueryStringConverter converter;

        /// <summary>
        /// Method that convert object parameters to string type
        /// </summary>
        /// <param name="params">Array of input parameter</param>
        /// <returns>Array of input paramter converted to string array</returns>
        private object[] ConvertParams(object[] @params)
        {
            object[] converted;
            if (null == @params || @params.Length <= 0)
            {
                converted = new object[0];
            }
            else
            {
                converted = new object[@params.Length];
                for (int i = 0; i < @params.Length; i++)
                {
                    if (null != @params[i] && Converter.CanConvert(@params[i].GetType()))
                    {
                        converted[i] = Converter.ConvertValueToString(@params[i], @params[i].GetType());
                    }
                    else
                    {
                        converted[i] = string.Empty;
                    }
                }
            }

            return converted;
        }

        /// <summary>
        /// Get url for preparing request.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <returns>Url fore request.</returns>
        private Uri GetServiceUrl(Message message)
        {
            Uri url;
            string baseUrl;
            if (message.Method.Method == HttpMethod.POST)
            {
                baseUrl = ServiceUrl.AbsoluteUri;
                if (Uri.UriSchemeHttp.Equals(ServiceUrl.Scheme))
                {
                    baseUrl = string.Format("{0}{1}",
                        Uri.UriSchemeHttps,
                        baseUrl.Substring(Uri.UriSchemeHttp.Length));
                }

                url = new Uri(baseUrl);
            }
            else
            {
                baseUrl = ServiceUrl.AbsoluteUri;
                if (Uri.UriSchemeHttps.Equals(ServiceUrl.Scheme))
                {
                    baseUrl = string.Format("{0}{1}",
                        Uri.UriSchemeHttp,
                        baseUrl.Substring(Uri.UriSchemeHttps.Length));
                }

                url = new Uri(string.Format("{0}{1}", baseUrl, message.Method.GetRequestBody()));
            }

            return url;
        }

        /// <summary>
        /// Method that create WebRequest.
        /// </summary>
        /// <param name="message">Message.</param>
        private void PrepareRequest(ref Message message)
        {
            message.Request = WebRequest.Create(GetServiceUrl(message));
            message.Request.Timeout = LastFmSettings.Instance.OperationTimeout.TotalMilliseconds;
            message.Request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8;";
            if (message.Method.Method == HttpMethod.POST)
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(message.Method.GetRequestBody());
                message.Request.ContentLength = byteArray.Length;
                message.Request.Method = HttpMethod.POST.ToString();
                using (Stream stream = message.Request.GetRequestStream())
                {
                    stream.Write(byteArray, 0, byteArray.Length);
                    stream.Close();
                }
            }
        }

        /// <summary>
        /// Perform WebRequest
        /// </summary>
        /// <param name="message">Message, will be initialized with result
        /// after performing of request</param>
        private void Process(ref Message message)
        {
            try
            {
                message.Response = message.Request.GetResponse();
                message.SetResponseStream(ReadAndClose(message.Response.GetResponseStream()));
            }
            catch (WebException ex)
            {
                message.Exception = LastFmException.CreateWebException(ex);
            }
        }

        /// <summary>
        /// Read and close stream.
        /// </summary>
        /// <param name="inputStream">Input stream.</param>
        /// <returns>MemoryStream.</returns>
        private Stream ReadAndClose(Stream inputStream)
        {
            if (null == inputStream)
            {
                return null;
            }

            MemoryStream ms = new MemoryStream();
            try
            {
                using (inputStream)
                {
                    const int readSize = 256;
                    byte[] buffer = new byte[readSize];

                    int count = inputStream.Read(buffer, 0, readSize);
                    while (count > 0)
                    {
                        ms.Write(buffer, 0, count);
                        count = inputStream.Read(buffer, 0, readSize);
                    }

                    ms.Position = 0;
                    inputStream.Close();
                }
            }
            catch
            {
                ms = null;
            }

            return ms;
        }

        #endregion

        #region Public part

        /// <summary>
        /// Invoke method
        /// </summary>
        /// <param name="msg">Input message</param>
        /// <returns>Output message</returns>
        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage mCall = msg as IMethodCallMessage;
            if (null != mCall)
            {
                try
                {
                    Message message;
                    using (message = SerializeRequest(Methods[mCall.MethodBase], mCall.Args))
                    {
                        BeforeSendRequest(ref message);

                        Process(ref message);

                        AfterReceiveReply(ref message);
                        if (null != message.Exception)
                        {
                            return new ReturnMessage(message.Exception, mCall);
                        }

                        object results = DeserializeReply(message, null);
                        return new ReturnMessage(results, null, 0, mCall.LogicalCallContext, mCall);
                    }
                }
                catch (TargetInvocationException ex)
                {
                    return new ReturnMessage(ex.InnerException, mCall);
                }
                catch (Exception ex)
                {
                    string errMessage = string.Format("{0} method can't be executed.", mCall.MethodName);
                    return new ReturnMessage(new InvalidOperationException(errMessage, ex), mCall);
                }
            }

            return new ReturnMessage(new InvalidOperationException("This method can't be executed."), null);
        }

        /// <summary>
        /// Returns the transparent proxy for the current instance of System.Runtime.Remoting.Proxies.RealProxy.
        /// </summary>
        /// <returns></returns>
        public new TChannel GetTransparentProxy()
        {
            TChannel channel = (TChannel)base.GetTransparentProxy();
            return channel;
        }

        #endregion

        #region Overrided

        public override string ToString()
        {
            return string.Format("Service: {0} - [{1}]",
                ServiceName,
                ServiceUrl);
        }

        #endregion
    }
}