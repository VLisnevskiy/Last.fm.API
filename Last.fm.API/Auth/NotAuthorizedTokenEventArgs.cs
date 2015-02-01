//-----------------------------------------------------------------------
// <copyright file="NotAuthorizedTokenEventArgs.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Last.fm.API.Auth
{
    /// <summary>
    /// Event arguments for not authorized token event
    /// </summary>
    public class NotAuthorizedTokenEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor of NotAuthorizedTokenEventArgs
        /// </summary>
        public NotAuthorizedTokenEventArgs()
        {
            Resolved = false;
        }

        /// <summary>
        /// New token. Has to be set by external system.
        /// </summary>
        public string NewToken { get; set; }

        /// <summary>
        /// Indicate if new token was set.
        /// </summary>
        public bool Resolved { get; set; }
    }
}