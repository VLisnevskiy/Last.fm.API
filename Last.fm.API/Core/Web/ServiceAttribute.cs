//-----------------------------------------------------------------------
// <copyright file="ServiceAttribute.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Last.fm.API.Core.Web
{
    /// <summary>
    /// Last.fm service attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class ServiceAttribute : Attribute
    {
        /// <summary>
        /// Name of service
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceAttribute()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of service</param>
        public ServiceAttribute(string name)
        {
            Name = name;
        }
    }
}