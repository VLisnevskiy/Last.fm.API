//-----------------------------------------------------------------------
// <copyright file="HttpMethod.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Last.fm.API.Core.Web
{
    /// <summary>
    /// Type of http request method
    /// </summary>
    public enum HttpMethod
    {
        /// <summary>
        /// POST method
        /// </summary>
        POST = 0x0,

        /// <summary>
        /// GET method
        /// </summary>
        GET = 0x1
    }
}