//-----------------------------------------------------------------------
// <copyright file="AuthServicesClient.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Last.fm.API.Core;
using Last.fm.API.Core.Settings;
using Last.fm.API.Core.Types;
using Last.fm.API.Core.Web;

namespace Last.fm.API.Auth
{
    internal class AuthServicesClient : BaseLastFmClient<IAuthServicesApi>, IAuthServices
    {
        #region IAuthServices methods

        public AuthToken GetToken()
        {
            string apiSig = BuildSignature(SigToken);
            var result = Channel.GetToken(ApiKey, apiSig);
            return result;
        }

        public AuthSession GetSession(string token)
        {
            try
            {
                return _GetSession(token);
            }
            catch (NotAuthorizedTokenException e)
            {
                if (null != notAuthorizedToken)
                {
                    NotAuthorizedTokenEventArgs eventArgs = new NotAuthorizedTokenEventArgs();
                    notAuthorizedToken.Invoke(this, eventArgs);
                    if (eventArgs.Resolved)
                    {
                        return _GetSession(eventArgs.NewToken);
                    }
                }

                throw e;
            }
        }

        private AuthSession _GetSession(string token)
        {
            string apiSig = BuildSignature(SigSession,
                string.IsNullOrWhiteSpace(token)
                ? LastFmSettings.FakeToken
                : token);
            AuthSession result = null;
            try
            {
                result = Channel.GetSession(ApiKey, apiSig, token);
            }
            catch (LastFmException e)
            {
                if (Constants.NotAuthorizedTokenCode == e.LastFmError.Code ||
                    Constants.InvalidMethodSignature == e.LastFmError.Code ||
                    Constants.ThisTokenHasExpired == e.LastFmError.Code ||
                    Constants.InvalidAuthenticationToken == e.LastFmError.Code)
                {
                    throw new NotAuthorizedTokenException(e);
                }

                throw e;
            }

            if (null != result && result.Success == LfmStatus.ok)
            {
                LastFmSettings.Instance.Token = token;
                LastFmSettings.Instance.UserSession = result;
            }

            return result;
        }

        public AuthSession GetSession()
        {
            return GetSession(LastFmSettings.Instance.Token);
        }

        private event EventHandler<NotAuthorizedTokenEventArgs> notAuthorizedToken;
        public event EventHandler<NotAuthorizedTokenEventArgs> NotAuthorizedToken
        {
            add { notAuthorizedToken += value; }
            remove { notAuthorizedToken -= value; }
        }

        #endregion

        #region IDisposable

        ~AuthServicesClient()
        {
            Dispose(false);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (null != notAuthorizedToken)
            {
                foreach (Delegate @delegate in notAuthorizedToken.GetInvocationList())
                {
                    notAuthorizedToken -= (EventHandler<NotAuthorizedTokenEventArgs>) @delegate;
                }
            }
        }

        #endregion

        internal const string SigSession = "api_key{0}methodauth.getSessiontoken{1}{2}";

        internal const string SigToken = "api_key{0}methodauth.getToken{1}";
    }
}
