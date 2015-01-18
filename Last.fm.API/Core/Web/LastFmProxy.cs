//-----------------------------------------------------------------------
// <copyright file="LastFmProxy.cs" company="Vyacheslav Lisnevskyi">
//     Copyright MyCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace Last.fm.API.Core.Web
{
    internal class LastFmProxy<TChannel> : RealProxy
    {
        private readonly TChannel target;

        public LastFmProxy(TChannel target)
            : base(typeof(TChannel))
        {
            this.target = target;
        }

        #region Obsolete variant

        /*public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage mCall = msg as IMethodCallMessage;

            try
            {
                if (null != mCall)
                {
                    MethodInfo method = mCall.MethodBase as MethodInfo;
                    if (null != method)
                    {
                        object results = method.Invoke(target, mCall.InArgs);

                        var res = new ReturnMessage(results, null, 0, mCall.LogicalCallContext, mCall);
                        return res;
                    }
                }

                throw new ArgumentException("Input message has bad format.\n" +
                                            "LastFmProxy couldn't continue his work.\n" +
                                            "Sorry!");
            }
            catch (TargetInvocationException ex)
            {
                return new ReturnMessage(ex.InnerException, mCall);
            }
            catch (Exception ex)
            {
                return new ReturnMessage(ex, mCall);
            }
        }*/

        #endregion

        public override IMessage Invoke(IMessage msg)
        {
            RealProxy realProxy = RemotingServices.GetRealProxy(target);
            var resMsg = realProxy.Invoke(msg);

            IMethodReturnMessage processedMsg = resMsg as IMethodReturnMessage;
            if (null != processedMsg)
            {
                if (null == processedMsg.Exception ||
                    processedMsg.Exception is LastFmException)
                {
                    return processedMsg;
                }

                return
                    new ReturnMessage(LastFmException.CreateWebException(processedMsg.Exception),
                    (IMethodCallMessage)msg);
            }

            return resMsg;
        }

        public new TChannel GetTransparentProxy()
        {
            TChannel channel = (TChannel)base.GetTransparentProxy();
            return channel;
        }
    }
}