//-----------------------------------------------------------------------
// <copyright file="WebMethodAttribute.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Last.fm.API.Core.Web
{
    /// <summary>
    /// Last.fm web method attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class WebMethodAttribute : Attribute
    {
        /// <summary>
        /// Name of last.fm web method
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of Http method
        /// </summary>
        public HttpMethod Method { get; set; }

        public WebMethodAttribute()
        {
            Method = HttpMethod.GET;
        }

        public WebMethodAttribute(string name)
        {
            Method = HttpMethod.GET;
            Name = name;
        }
    }
}