//-----------------------------------------------------------------------
// <copyright file="SettingsElementAttribute.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Last.fm.API.Core.Settings
{
    [AttributeUsage(AttributeTargets.Property |
        AttributeTargets.Field |
        AttributeTargets.Parameter |
        AttributeTargets.ReturnValue)]
    internal class SettingsElementAttribute : Attribute
    {
        public SettingsElementAttribute()
        {
        }

        public SettingsElementAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}