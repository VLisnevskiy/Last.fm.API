//-----------------------------------------------------------------------
// <copyright file="NotAuthorizedTokenException.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Last.fm.API.Core.Web;

namespace Last.fm.API.Auth
{
    public class NotAuthorizedTokenException : LastFmException
    {
        public NotAuthorizedTokenException(LastFmException exception)
            : base("This token has not been authorized", exception)
        {
            if (null != exception)
            {
                LastFmError = exception.LastFmError;
            }
        }
    }
}
