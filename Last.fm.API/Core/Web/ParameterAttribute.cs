//-----------------------------------------------------------------------
// <copyright file="ParameterAttribute.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Last.fm.API.Core.Web
{
    /// <summary>
    /// Last.fm parameter attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class ParameterAttribute : Attribute
    {
        /// <summary>
        /// Name of paramter for web request
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor of ParameterAttribute. Create new instance
        /// </summary>
        public ParameterAttribute()
        {
        }

        /// <summary>
        /// Constructor of ParameterAttribute. Create new instance
        /// </summary>
        /// <param name="name">Name of paramter</param>
        public ParameterAttribute(string name)
        {
            Name = name;
        }
    }
}